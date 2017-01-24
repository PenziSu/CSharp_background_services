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
            string uri = "http://web.ccgh/";
            var pageSource = string.Empty;                 
            CookieContainer CookiesPad = new CookieContainer();            
            HttpWebRequest rqt = (HttpWebRequest)WebRequest.Create(uri);
            rqt.Timeout = 5000;
            rqt.Accept = "*/*";            
            rqt.ServicePoint.Expect100Continue = false;
            rqt.ContentType = "application/x-www-form-urlencoded";
            rqt.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            //rqt.Method = "POST";
            rqt.KeepAlive = true;                       
            rqt.AllowAutoRedirect = true;
            //rqt.AllowWriteStreamBuffering = false;
            rqt.ServicePoint.UseNagleAlgorithm = false;
            rqt.CookieContainer = CookiesPad;
            rqt.ServicePoint.ConnectionLimit = int.MaxValue;
            var rspos = (HttpWebResponse)rqt.GetResponse();
            foreach ( Cookie cookie in rspos.Cookies)
            {
                CookiesPad.Add(cookie);
            }
            Stream stream = rspos.GetResponseStream();
            Encoding encode = Encoding.GetEncoding("big5");
            StreamReader streamReader = new StreamReader(stream, encode);
            pageSource = streamReader.ReadToEnd();
            


            Console.WriteLine(pageSource);
            Console.WriteLine("STOP!");
            Console.ReadLine();                        
        }       
    }
}
