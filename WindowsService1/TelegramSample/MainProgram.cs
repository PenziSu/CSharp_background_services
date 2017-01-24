using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using TelegramSample.Models;

namespace TelegramSample
{   
    public class MainProgram
    {        
        public static void Main(string[] args)
        {
            CityCrawler();
        }

        public static void CityCrawler()
        {

            var cityUrl = "http://hotels.ctrip.com/citylist";
            var cityList = new List<City>();
            var cityCrawler = new SimpleCrawler();

            //OnStart
            cityCrawler.OnStart += (s, e) =>
            {
                Console.WriteLine("爬蟲開始抓取地址:" + e.Uri.ToString());
            };

            //OnError
            cityCrawler.OnError += (s, e) =>
            {
                Console.WriteLine("爬蟲抓取出現錯誤:" + e.Uri.ToString() + "，異常狀態:" + e.Exception.Message);
            };

            //OnCompleted
            cityCrawler.OnCompleted += (s, e) =>
            {              
                var links = Regex.Matches(e.PageSource, @"<a[^>]+href=""*(?<href>/hotel/[^>\s]+)""\s*[^>]*>(?<text>(?!.*img).*?)</a>", RegexOptions.IgnoreCase);
                foreach (Match match in links)
                {
                    var city = new City
                    {
                        CityName = match.Groups["text"].Value,
                        Uri = new Uri("http://hotels.ctrip.com" + match.Groups["href"].Value)                    
                    };
                    if (!cityList.Contains(city)) cityList.Add(city);
                    Console.WriteLine(city.CityName + "|" + city.Uri);
                }
                Console.WriteLine("===================================================");
                Console.WriteLine("爬蟲抓取任務完成!合計：" + links.Count + " 個城市。");
                Console.WriteLine("耗時：" + e.Milliseconds + "毫秒");
                Console.WriteLine("線程：" + e.ThreadId);
                Console.WriteLine("地址：" + e.Uri.ToString());
                Console.ReadLine();
            };

            cityCrawler.Start(new Uri(cityUrl)).Wait();
        }
    }
}