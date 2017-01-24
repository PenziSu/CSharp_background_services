using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace BBSCrawler
{
    class Program
    {                      
        static void Main(string[] args)
        {
            //string uri = "http://web3.ccgh/ccghiso/";
            //建立網址
            string uri = "http://web.ccgh/";
            //初始畫內容
            var pageSource = string.Empty;
            //建立Big5編碼
            Encoding big5Code = Encoding.GetEncoding("big5");
            //建立登入資料
            string data = "T1=13432&T2=1qa2ws3ed&B1=登入";
            //將登入資料轉換編碼變成payload
            byte[] payload = Encoding.ASCII.GetBytes(data);
            //建立Cookie容器
            CookieContainer CookiesBox = new CookieContainer();                        
            //建立Hppt請求資訊
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri); //設定網址
            req.Timeout = 5000; //設定逾時設定5000
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"; //設定標題
            req.ServicePoint.Expect100Continue = false; 
            req.ContentType = "application/x-www-form-urlencoded"; //設定內容型態
            req.ContentLength = payload.Length; //設定內容長度
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36"; //模擬瀏覽器
            req.KeepAlive = true; 
            req.Referer = "http://web.ccgh/"; //設定參考網址
            req.AllowAutoRedirect = true; //設定重新導向
            //req.AllowWriteStreamBuffering = false;
            req.ServicePoint.UseNagleAlgorithm = false; //設定演算法Nagle
            req.CookieContainer = CookiesBox; //設定Cookie
            req.ServicePoint.ConnectionLimit = int.MaxValue; //設定最大連線數
            req.Method = "POST";  //設定提交方法

            //提交包含資料的請求
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(payload, 0, payload.Length);
            }

            //取得回應
            var rspos = (HttpWebResponse)req.GetResponse();

            //以迴圈將cookie資訊寫入Cookie儲存器            
            foreach (Cookie cookie in rspos.Cookies)
            {
                CookiesBox.Add(cookie);
                Console.WriteLine("=======");
                Console.WriteLine(cookie);
                Console.WriteLine("=======");
            }

            //將回應轉成Stream
            Stream stream = rspos.GetResponseStream();

            //將串流重新編碼後放入串流讀取器
            StreamReader streamReader = new StreamReader(stream, big5Code);

            //將串流資訊填入字串變數
            pageSource = streamReader.ReadToEnd();

            //呈現回應內容
            //Console.WriteLine(pageSource);
            Console.WriteLine("Show me the COOKIE");
            Console.WriteLine(CookiesBox);

            stream.Close();
            streamReader.Close();
            rspos.Close();

            Console.ReadKey();                            
        }       
    }
}
