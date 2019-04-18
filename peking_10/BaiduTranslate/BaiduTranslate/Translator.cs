using System;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
namespace BaiduTranslate
{

    //baidu翻译 http://developer.baidu.com  可以申请key
    //文档 http://developer.baidu.com/wiki/index.php?title=帮助文档首页/百度翻译/翻译API

    public class Translator
    {
        static void Main(string[]args)
        {
            Test();

            //TranslateFile(@"..\..\..\21-eng.srt", @"..\..\..\21-ch.srt");
            //Console.WriteLine("ok");
            
        }
        static void TranslateFile(string srcFile, string destFile)
        {
            string [] lines = File.ReadAllLines(srcFile);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                if(IsEnglish(line)) if(!dict.ContainsKey(line)) dict.Add(line, line);
            }
            fromEnglishToChinese(dict);
            string[] results = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (!string.IsNullOrEmpty(line) && dict.ContainsKey(line)) results[i] = dict[line];
                else results[i] = line;
            }
            File.WriteAllLines(destFile, results, Encoding.Default);
        }
        static bool IsEnglish(string line)
        {
            if (string.IsNullOrEmpty(line)) return false;
            //bool hasLetter = false;
            foreach (char c in line) if (char.IsLetter(c)) return true;
            return false;
        }

        static void Test()
        {
            string text = "hello\nworld";
            string[] lines = text.Split('\n');
            string[] results = fromEnglishToChinese(lines);
            foreach (string line in results) Console.WriteLine(line);
        }

        public const string TRANSLATE_LANGUAGE_CHINESE = "zh";
        public const string TRANSLATE_LANGUAGE_ENGLISH = "en";
        public const string TRANSLATE_LANGUAGE_JAPANNESE = "jp";
        public const string TRANSLATE_LANGUAGE_AUTO = "auto";
        private static string apikey = "lLnAVjWqMutV9GzYWmndR7Ku";
        public static string fromEnglishToChinese(string src)
        {
            return Translate(src, TRANSLATE_LANGUAGE_ENGLISH, TRANSLATE_LANGUAGE_CHINESE);
        }
        public static string Translate(string src,string from,string to)
        {
            string text = getRequest(src,from,to);
            BaiduResult r = jsonGet(text);
            if (r != null && r.trans_result != null&&r.trans_result.Length > 0)
                return r.trans_result[0].dst;
            else
                return "";
        }
        public static void fromEnglishToChinese(Dictionary<string, string> src)
        {
            Translate(src, TRANSLATE_LANGUAGE_ENGLISH, TRANSLATE_LANGUAGE_CHINESE);
        }
        public static void Translate(Dictionary<string, string> src,string from = TRANSLATE_LANGUAGE_ENGLISH,string to=TRANSLATE_LANGUAGE_CHINESE)
        {
            int size = src.Count;
            StringBuilder sb = new StringBuilder();
            int count = 0;
            string[] keys=new string[src.Count];
            src.Keys.CopyTo(keys, 0);
            foreach (string key in keys)
            {
                sb.AppendLine(key);
                count++;
                if(count>=10){
                    string text = getRequest(sb.ToString(),from,to);
                    BaiduResult r = jsonGet(text);
                    if (r != null && r.trans_result != null)
                    {
                        foreach (BaiduResult.Trans_result tr in r.trans_result)
                        {
                            src[tr.src] = tr.dst;
                        }
                    }
                    sb.Remove(0, sb.Length);
                    //sb.Clear();
                }

            }
            if (sb.Length > 0)
            {
                string text = getRequest(sb.ToString(), from, to);
                BaiduResult r = jsonGet(text);
                if (r != null && r.trans_result != null)
                {
                    foreach (BaiduResult.Trans_result tr in r.trans_result)
                    {
                        src[tr.src] = tr.dst;
                    }
                }
            }
        }

        public static string[] fromEnglishToChinese(string[] src)
        {
            return Translate(src, TRANSLATE_LANGUAGE_ENGLISH, TRANSLATE_LANGUAGE_CHINESE);
        }
        public static string[] Translate(string[] src, string from, string to)
        {
            StringBuilder sb = new StringBuilder();
            int size = src.Length;
            List<string> ls = new List<string>();
            int i;
            for (i = 0; i < size;i+=10 )
            {
                sb.Remove(0, sb.Length);
                //sb.Clear();
                for (int j = 0; j < 10;j++ )
                {
                    if(i+j<size)
                        sb.AppendLine(src[i+j]);
                }
                string text = getRequest(sb.ToString(), from, to);
                BaiduResult r = jsonGet(text);
                if (r != null && r.trans_result != null)
                {
                    foreach (BaiduResult.Trans_result tr in r.trans_result)
                    {
                        ls.Add(tr.dst);
                    }
                }
            }
            return ls.ToArray();
        }

        protected static string getRequest(string src,string from,string to)
        {
            //Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(src));
            string encode = System.Web.HttpUtility.UrlEncode(src, System.Text.Encoding.UTF8);
            string address = string.Format("http://openapi.baidu.com/public/2.0/bmt/translate?client_id={0}&q={1}&from={2}&to={3}", apikey, encode,from,to);
            HttpWebRequest request;
            request = (HttpWebRequest)HttpWebRequest.Create(address);
            request.Method = "GET";
            request.ProtocolVersion = HttpVersion.Version11;
            //request.Connection = "keep-alive";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.861.0 Safari/535.2";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Timeout = 10000;
            //request.Headers.Add("Connection", "keep-alive"); 

            request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            request.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");
            request.CookieContainer = new CookieContainer();

            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            Stream st;
            st = response.GetResponseStream();
            GZipStream temp = null;
            StreamReader stReader;
            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                temp = new GZipStream(st, CompressionMode.Decompress, true);
                stReader = new StreamReader(temp, Encoding.Default);
            }
            else
            {
                stReader = new StreamReader(st, Encoding.Default);
            }

            string text;
            text = stReader.ReadToEnd();

            stReader.Close();
            if (temp != null)
                temp.Close();
            st.Close();
            return text;
        }

        public static BaiduResult jsonGet(string jsonString)
        {
            if (jsonString.Length > 0)
            {
                var ms = new MemoryStream(Encoding.Default.GetBytes(jsonString));
                return (BaiduResult)new DataContractJsonSerializer(typeof(BaiduResult)).ReadObject(ms);
            }
            return null;
        }
    }

    public class BaiduResult
    {
        [DataMember(Order = 0, IsRequired = true)]
        public string from;
        [DataMember(Order = 1)]
        public string to;
        public class Trans_result
        {
            public string src;
            public string dst;
        }
        [DataMember(Order = 2)]
        public Trans_result[] trans_result;
    }
 
}
