/*
 *Author:   GalaIO
 *Date:     2016-3-30
 *Describe: easy to request.
 */
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Net;

namespace HTTProxy
{
    /*
     * 常见的媒体格式类型如下：

        text/html ： HTML格式
        text/plain ：纯文本格式      
        text/xml ：  XML格式
        image/gif ：gif图片格式    
        image/jpeg ：jpg图片格式 
        image/png：png图片格式
       以application开头的媒体格式类型：

       application/xhtml+xml ：XHTML格式
       application/xml     ： XML数据格式
       application/atom+xml  ：Atom XML聚合格式    
       application/json    ： JSON数据格式
       application/pdf       ：pdf格式  
       application/msword  ： Word文档格式
       application/octet-stream ： 二进制流数据（如常见的文件下载）
       application/x-www-form-urlencoded ：
     * */
    class Request_MIME
    {
        public static string html = "text/html";
        public static string plain = "text/plain";
        public static string gif = "image/gif";
        public static string jpeg = "image/jpeg";
        public static string png = "image/png";
        public static string xhtml = "application/xhtml+xml";
        public static string xml = "application/xml";
        public static string json = "application/json";
        public static string pdf = "application/pdf";
        public static string word = "application/msword";
        public static string binary = "application/octet-stream";
        public static string keyValue = "application/x-www-form-urlencoded";
    }

    class Request
    {
        //使用post传输数据
        public static string post(string url, string data, string conType, Encoding coding)
        {
            Exception tmpE = null;
            string resultBuf = null;
            HttpWebRequest req = null;
            Stream reqStream = null;
            HttpWebResponse rsp = null;
            Stream rspStream = null;
            try
            {
                req = (HttpWebRequest)WebRequest.Create(url);
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int senLen = buffer.Length-1;
                req.Method = "post";
                req.ContentType = conType;
                req.ContentLength = senLen;
                reqStream = req.GetRequestStream();
                reqStream.Write(buffer, 0, senLen);
                reqStream.Close();

                //获取响应
                rsp = (HttpWebResponse)req.GetResponse();
                rspStream = rsp.GetResponseStream();
                StreamReader reader = new StreamReader(rspStream, coding);
                resultBuf = reader.ReadToEnd();
                //Console.WriteLine(resultFromRemote);
                rsp.Close();
                rspStream.Close();
            }
            catch (Exception e)
            {
                //保存异常实例
                tmpE = e;
            }finally{
                //保证非托管资源的释放
                if(rsp != null){
                    rsp.Close();
                }
                if(reqStream != null){
                    reqStream.Close();
                }
                if(rspStream != null){
                    rspStream.Close();
                }
                if(req != null){
                    //关闭http请求
                    req.Abort();
                }
            }
            //如果发生异常，抛出
            if (tmpE != null) throw tmpE;
            //否则返回正确的字符串
            return resultBuf;
        }

        //上传某数据
        public static string get(string url, string data, Encoding coding)
        {
            Exception tmpE = null;
            string resultBuf = null;
            HttpWebRequest req = null;
            HttpWebResponse rsp = null;
            Stream rspStream = null;
            try
            {
                string getUrl = url;
                if (data != null) getUrl += "?" + data;
                req = (HttpWebRequest)WebRequest.Create(getUrl);
                req.Method = "get";
                //获取响应
                rsp = (HttpWebResponse)req.GetResponse();
                rspStream = rsp.GetResponseStream();
                StreamReader reader = new StreamReader(rspStream, coding);
                resultBuf = reader.ReadToEnd();
                rsp.Close();
                rspStream.Close();
            }
            catch (Exception e)
            {
                //保存异常实例
                tmpE = e;
            }
            finally
            {
                //保证非托管资源的释放
                if (rsp != null)
                {
                    rsp.Close();
                }
                if (rspStream != null)
                {
                    rspStream.Close();
                }
                if (req != null)
                {
                    //关闭http请求
                    req.Abort();
                }
            }
            //如果发生异常，抛出
            if (tmpE != null) throw tmpE;
            //否则返回正确的字符串
            return resultBuf;
        }
    }
}