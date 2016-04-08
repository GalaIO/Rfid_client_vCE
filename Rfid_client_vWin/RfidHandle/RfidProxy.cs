using System;
/*
 *Author:   GalaIO
 *Date:     2016-3-30
 *Describe: The proxy to handle RFID.
 */
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Setting;
using HTTProxy;
using Json;
using R2K;
using System.Runtime.InteropServices;
namespace RfidHandle
{
    public sealed class EPC_data : IComparable
    {
        public string epc;
        public int count;
        public int devNo;
        public byte antNo;
        //添加超时标记
        public int timeOut;
        int IComparable.CompareTo(object obj)
        {
            EPC_data temp = (EPC_data)obj;
            {
                return string.Compare(this.epc, temp.epc);
            }
        }
    }
    class RfidProxy
    {
        //创建json生成字串，缓存
        private JsonGen jsonBuf = null;
        //epc 
        public static List<EPC_data> rfids = new List<EPC_data>();
        //设置时钟间隔时间，根据实际情况调整大小
        public static int rfid_report_interval = 1000; // ms
        public static int rfid_scan_interval = 300; // ms
        public static int rfid_opencheck_interval = 2000; // ms

        public static int rfid_timeOut_second = 10; // = 超时分钟*60s*rfid_report_interval/1000

        //store username
        private static string username = null;
        //store userpasswd
        private static string userpasswd = null;
        //控制关闭句柄
        private bool isOpened = false;
        private static RfidProxy _instance;
        //单例模式 同步信号量
        private static readonly object mutex = new object();
        //同步ui线程和委托线程的共享内存
        public static readonly object rfidUpdataMutex = new object();
        //新建 读取委托
        public R2k.HANDLE_FUN asynReadTag = new R2k.HANDLE_FUN(HandleTagData);
        
        //委托类型
        public delegate bool AsycnHandle(object data);


        //单例模式 实体
        public static RfidProxy Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (mutex)
                    {
                        _instance = new RfidProxy();
                    }
                }
                return _instance;
            }
        }

        //私有的构造函数
        private RfidProxy()
        {
            jsonBuf = new JsonGen();
        }

        //关闭rfid
        public bool close(){
            //如果打开就关闭
            if (isOpened)
            {
                R2k.deviceDisconnect();
                R2k.deviceUnInit();
                isOpened = false;
                return true;
            }
            MessageBox.Show("请先打开硬件！");
            return false;
        }
        //异步打开rfid
        private AsycnHandle openDevice = delegate(object data)
        {
            
            //如果关闭再打开
            if (false == RfidProxy.Instance.isOpened)
            {
                if (0 != R2k.deviceInit(Encoding.ASCII.GetBytes(HttpConfig.Instance.UrlDeviceIP), 0, HttpConfig.Instance.UrlDevicePortOrBaud))
                {
                    MessageBox.Show("打开设备失败!请检查硬件！");
                    return false;
                }
                if (0 != R2k.deviceConnect())
                {
                    MessageBox.Show("打开设备失败!请检查硬件！");
                    return false;
                }
                RfidProxy.Instance.isOpened = true;
                return true;
            }
            MessageBox.Show("请先关闭硬件！");
            return false;
        };
        private IAsyncResult openDeviceIAsyncResult;
        //使用异步方法打开
        public bool asynOpen(){
            openDeviceIAsyncResult = openDevice.BeginInvoke(null, null, null);
            return true;
        }
        //检查打开情况
        public bool checkOpened()
        {
            return openDevice.EndInvoke(openDeviceIAsyncResult);

        }
        //开始扫描
        public bool scanRfid()
        {
            R2k.BeginMultiInv(asynReadTag);
            return true;
        }
        //结束扫描
        public bool stopScanRfid()
        {
            R2k.StopInv();
            return true;
        }
        //定义检查 标签的时效性，即在超过一定时间没有检测到标签，认为已丢失
        public void clearOldTag()
        {
            for (int i = 0; i < rfids.Count; i++ )
            {
                //超时即清除
                if (rfids[i].timeOut >= RfidProxy.rfid_timeOut_second)
                {
                    rfids.Remove(rfids[i]);
                }
                else
                {
                    //每次上报时间到了，自加一次超时记录
                    rfids[i].timeOut++;
                }
            }
        }
        //定义上报数据的异步调用方法
        public bool uploadRfidData()
        {
            lock (rfidUpdataMutex)
            {
                //先清除 超时的标签
                clearOldTag();
                string reqData = RfidProxy.Instance.genRfidUploadData(RfidProxy.rfids);
                string result = null;
                try
                {
                    result = Request.post(HttpConfig.Instance.UrlReportRfid, reqData, Request_MIME.json, Encoding.GetEncoding("utf-8"));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                return true;
            }
        }
        private string genRfidUploadData(List<EPC_data> rfids)
        {

            jsonBuf.resetJson();
            jsonBuf.startJson();

            foreach (EPC_data epc in rfids)
            {
                jsonBuf.addStringToArray(epc.epc);
            }
            jsonBuf.endJson();
            char[] tt = jsonBuf.toJson().ToCharArray();
            tt[0] = '[';
            tt[tt.Length - 2] = ']';
            return new string(tt);
        }
        public static void HandleTagData(byte cmdID, IntPtr pData, int length)
        {
            string tmpEPC = "";
            if (length <= 4) return;
            byte[] data = new byte[32];
            Marshal.Copy(pData, data, 0, length);
            for (int j = 0; j < length - 4; ++j)
            {
                tmpEPC += string.Format("{0:X2} ", data[j]);
            }
            lock (rfidUpdataMutex)
            {
                int i;
                for (i = 0; i < rfids.Count; ++i)
                {
                    if (tmpEPC == rfids[i].epc)
                    {
                        rfids[i].count++;
                        rfids[i].antNo = data[length - 1];
                        rfids[i].devNo = 0;
                        rfids[i].timeOut = 0;
                        break;
                    }
                }
                //发现新标签
                if (i >= rfids.Count)
                {
                    EPC_data epcdata = new EPC_data();
                    epcdata.epc = tmpEPC;
                    epcdata.antNo = data[length - 1];
                    epcdata.devNo = 0;
                    epcdata.count = 1;
                    //清空标记
                    epcdata.timeOut = 0;
                    rfids.Add(epcdata);
                }
            }
        }
        //登陆函数，返回是否登陆成功
        public bool login(string user, string passwd)
        {
            //清空用户缓存列表
            //taskList.Clear();
            //更新用户名密码
            username = user;
            userpasswd = passwd;
            //请求数据
            string taskData = null;
            try
            {
                taskData = Request.get(HttpConfig.Instance.UrlLogin,
                                        string.Format("username={0}&password={1}", RfidProxy.username, RfidProxy.userpasswd),
                                        Encoding.GetEncoding("utf-8"));
            }
            catch (Exception e)
            {
                //请求数据有误，显示异常，直接返回
                MessageBox.Show(e.Message);
                return false;
            }
            if (taskData == null)
            {
                return false;
            }
            string taskListInfo = JsonParser.findNextArray(taskData, null, 0);
            //如果不能正常解析json数据，返回服务器返回的错误
            if (taskListInfo == null)
            {
                //MessageBox.Show("没有找到有效数据！请重新登录");
                MessageBox.Show(taskData);
                return false;
            }
            return true;
        }

    }
}