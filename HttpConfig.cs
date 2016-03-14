
namespace proxy
{
    internal class HttpConfig
    {
        private readonly string url_login;  // 登录
        private string url_shop_in;    // 入库
        private string url_shop_out;  // 出库
        private string url_sku_online;  // 上柜
        private string url_sku_offline;  // 下柜
        private readonly string url_report_rfid;  // 上报 RFID 监控数据
        //private string url_products = "";
        //private string url_shopin_ui = "";

        private const int rfid_timeout = 10000;  // (ms)
        private const int rfid_report_interval = 7; // second

        private string host;

        private static HttpConfig _instance;
        private static readonly object mutex = new object();

        private HttpConfig()
        {

            //host = "http://192.168.0.102:8080";  //测试url
            //host = "http://rfid.jackon.me:80";    //服务器url
            //host = "http://123.57.80.232:8000";
            host = "http://192.168.0.112:8000";    //本地url

            url_login = host + "/api/auth";
            url_shop_in = host + "/products/shopin/";
            url_shop_out = host + "/api/shopout";
            url_sku_online = host + "/api/url_sku_online";
            url_sku_offline = host + "/api/url_sku_offline";
            url_report_rfid = host + "/api/report_rfid";
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

        public int RfidReportInterval
        {
            get { return rfid_report_interval; }
        }

        public string UrlReportRfid
        {
            get { return url_report_rfid; }
        }
        public string Host
        {
            get { return host; }
        }

        public int RfidTimeout
        {
            get { return rfid_timeout; }
        }
    }
}
