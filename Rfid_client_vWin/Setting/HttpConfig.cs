/*
 *Author:   GalaIO
 *Date:     2016-3-30
 *Describe: The url.
 */
using System.Reflection;
namespace Setting
{
    internal class HttpConfig
    {
        private readonly string url_login;  // 登录
        private readonly string url_report_rfid;  // 上报 RFID 监控数据
        private readonly string url_device_ip;//监控设备的ip地址
        private readonly uint url_device_portorbaud;//监控设备的端口号

        private string host;

        private static HttpConfig _instance;
        private static readonly object mutex = new object();

        private HttpConfig()
        {

            //host = "http://rfid.jackon.me:80";    //服务器url
            /*host = "http://192.168.0.112:8000";    //本地url

            url_device_ip = "192.168.0.200";    //监控设备的ip地址
            url_device_portorbaud = 20058;
            */

            string dir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);
            host = IniReader.GetINI("HTTP Config", "HOST", "http://192.168.0.112", dir + "\\Config.ini") + ":" + IniReader.GetINI("HTTP Config", "PORT", "8000", dir + "\\Config.ini");
            url_device_ip = IniReader.GetINI("Device Config", "DEVICE_IP", "192.168.0.200", dir + "\\Config.ini");
            url_device_portorbaud = uint.Parse(IniReader.GetINI("Device Config", "DEVICE_PORTBAUD", "20058", dir + "\\Config.ini"));

            url_login = host + "/api/auth";
            url_report_rfid = host + "/monitor/report-rfid";
        }

        public static HttpConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (mutex)
                    {
                        _instance = new HttpConfig();
                    }
                }
                return _instance;
            }
        }

        public string UrlLogin
        {
            get { return url_login; }
        }

        public string UrlDeviceIP
        {
            get { return url_device_ip; }
        }
        public uint UrlDevicePortOrBaud
        {
            get { return url_device_portorbaud; }
        }
        public string UrlReportRfid
        {
            get { return url_report_rfid;}
        }
        public string Host
        {
            get { return host; }
        }

    }
}
