using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.pracSelf.IO
{
    public class FileOperatecs
    {
        /// <summary>
        /// 根据网络路径下载文件
        /// </summary>
        public void downLoad(string filename)
        {
            try
            {
                WebClient wc = new WebClient()
                {
                    //Credentials = new NetworkCredential("Administrator", "Iphone6")
                    Credentials = CredentialCache.DefaultCredentials
                };
                wc.DownloadFile(@"\\192.168.1.131\share\"+filename,@"D:\"+filename);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void downLoad1(string filename)
        {
            try
            {
                WebClient client = new WebClient()
                {
                    //Credentials = new NetworkCredential("Administrator", "Iphone6")
                    Credentials = CredentialCache.DefaultCredentials
                };
                Stream str = client.OpenRead(@"\\192.168.1.131\share\" + filename);
                StreamReader reader = new StreamReader(str);
                
                int allmybyte = (int)reader.BaseStream.Length;
                byte[] mbyte = new byte[allmybyte];
                int length = 4 * 1024 * 1024;
                int startmbyte = 0;
                while (allmybyte > 0)
                {
                    if (allmybyte<length)
                    {
                        length = allmybyte;
                    }
                    //Task<int> m = str.ReadAsync(mbyte, startmbyte, length);
                    int m = str.Read(mbyte, startmbyte, length);
                    if (m == 0)
                        break;
                    startmbyte += m;
                    allmybyte -= m;
                }
                reader.Dispose();
                str.Dispose();
                string path = @"F:\" + filename;
                FileStream fstr = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                fstr.Write(mbyte, 0, startmbyte);
                fstr.Flush();
                fstr.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        /// <summary>
        /// 根据字符流下载文件
        /// 详情见csdn
        /// </summary>
        /// <param name="fileStr"></param>
        public void downLoad(){ }
        public bool upload(string path) { return true; }
    }
}
