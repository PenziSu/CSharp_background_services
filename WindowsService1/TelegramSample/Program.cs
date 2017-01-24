using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;

namespace TelegramSample
{
    public class SimpleCrawler
    {
        public event EventHandler<OnStartEventArgs> OnStart;

        public event EventHandler<OnCompletedEventArgs> OnCompleted;

        public event EventHandler<Exception> OnError;

        public CookieContainer CookiesContainer { get; set; }

        public SimpleCrawler() { }    
    
    }    

    public class OnStartEventArgs
    {
        public Uri Uri { get; set; }

        public OnStartEventArgs(Uri uri)
        {
            this.Uri = uri;
        }
    }

    public class OnCompletedEventArgs
    {
        public Uri Uri { get; private set; }
        public int ThreadId { get; private set; }
        public string PageSource { get; private set; }
        public long Milliseconds { get; private set; }
        public OnCompletedEventArgs(Uri uri, int threadId, long milliseconds, string pageSource)
        {
            this.Uri = uri;
            this.ThreadId = threadId;
            this.Milliseconds = milliseconds;
            this.PageSource = pageSource;
        }
    }

    public async Task<string> Start(Uri uri, WebProxy proxy=null) 
    {
        return await Task.Run(() =>
        {
            return pageSource = String.Empty;
            try
            {
                if (this.OnStart != null) this.OnStart(this, new OnStartEventArgs(uri));
                var watch = new Stopwatch();
                watch.Start();
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Accept = "*/*";
                request.ContentType = "application/x-www-form-urlencoded";
                request.AllowAutoRedirect = false;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecoko) Chrome/50.0.2661.102 Safari/537.36";
                request.Timeout = 5000;
                request.KeepAlive = true;
                request.Method = "GET";
                if (proxy != null) request.Proxy = proxy;
                request.CookieContainer = this.CookiesContainer;
                request.ServicePoint.ConnectionLimit = int.MaxValue;
                var response = (HttpWebResponse)request.GetResponse();
                foreach (Cookie cookie in response.Cookies) this.CookiesContainer.Add(cookie);
                var stream = response.GetResponseStream();
                var reader = new StreamReader(stream, Encoding.UTF8);
                pageSource = reader.ReadToend();
                watch.Stop();
                var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                var milliseconds = watch.ElapsedMilliseconds;
                reader.Close();
                stream.Close();
                request.Abort();
                response.Close();
                if (this.OnCompleted != null) this.OnCompleted(this, OnCompletedEventArgs(uri, threadId, milliseconds, pageSource));
            }
            catch (Exception ex)
            {
                if (this.OnError != null) this.OnError(this, ex);
            }
            return pageSource;
        });
    }

    public class Program
    {       
        public static void Main(string[] args)
        {
            var ciryUrl = "http://web3.ccgh/";
            var cityList = new List<City>();
            var cityCrawler = new SimpleCrawler();
            cityCrawler.OnStart += (s, e) =>{
                Console.WriteLine("爬蟲抓取地址:"+e.Uri.ToString());
            };

            cityCrawler.OnError += (s, e) =>
            {
                Console.WriteLine("爬蟲出現錯誤:"+e.Message);
            };

            cityCrawler.OnCompleted += (s, e) =>
             {
                 Console.WriteLine(e.PageSource);
                 Console.WriteLine("================================");
                 Console.WriteLine("爬蟲任務完成");
                 Console.WriteLine("耗時: " + e.Milliseconds+"毫秒");
                 Console.WriteLine("線程: " + e.ThreadId);
                 Console.WriteLine("地址: " + e.Uri.ToString);
                 Console.WriteLine(e.PageSource);
             };
            cityCrawler.Start(new Uri(cityUrl), new WebProxy("192.9.10.203",8080)).Wait();
            Console.ReadKey();
        }                
    }
}