using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

namespace SimpleWebCrawler
{


    public class Crawler
    {
        private WebClient webClient = new WebClient();
        private Hashtable urls = new Hashtable();
        private int count = 0;

        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();

            string startUrl = "http://x77613.com/bbs/thread.php?fid=18";
            if( args.Length>=1 ) startUrl = args[0];

            myCrawler.urls.Add(startUrl, false); //加入初始页面

            new Thread(new ThreadStart(myCrawler.Crawl)).Start(); //开始爬行
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了....");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys) //找到一个还没有下载过的链接
                {
                    if ((bool)urls[url]) continue; //已经下载过的，不再下载
                    current = url;
                }
                if (current == null || count > 10) break;

                Console.WriteLine("爬行" + current + "页面！");

                string html = DownLoad(current); //下载

                urls[current] = true;
                count++;

                Parse(html); //解析，并加入新的链接
            }
            Console.WriteLine("爬行结束");

        }

        public string DownLoad(string url)
        {
			try
			{
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
				req.Timeout = 30000;
				HttpWebResponse response = (HttpWebResponse)req.GetResponse();
				byte[] buffer = ReadInstreamIntoMemory(response.GetResponseStream());
				string fileName = count.ToString();
				FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
				fs.Write(buffer, 0, buffer.Length);
				fs.Close();
				string html = Encoding.UTF8.GetString(buffer);
				return html;				
			}
			catch 
			{
			}
			return "";
        }

        public void Parse(string html)
        {
            string strRef = @"(href|HREF|src|SRC)[ ]*=[ ]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');
                if( strRef.Length==0 ) continue;

                if (urls[strRef] == null) urls[strRef] = false;
            }
        }

        private static byte[] ReadInstreamIntoMemory(Stream stream)
        {
            int bufferSize = 16384;
            byte[] buffer = new byte[bufferSize];
            MemoryStream ms = new MemoryStream();
            while (true)
            {
                int numBytesRead = stream.Read(buffer, 0, bufferSize);
                if (numBytesRead <= 0) break;
                ms.Write(buffer, 0, numBytesRead);
            }
            return ms.ToArray();
        }
    }
}
