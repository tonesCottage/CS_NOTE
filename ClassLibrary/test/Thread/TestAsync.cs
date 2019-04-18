using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Test.test.ThreadT
{
    public class TestAsync
    {
        #region webRequest
        public void T_Invoke()
        {
            var request = WebRequest.Create("http://www.sina.com.cn");
            //io  yibu
            request.BeginGetRequestStream(AsyncCallbackImpl, request);
        }
        public void AsyncCallbackImpl(IAsyncResult ar)
        {
            WebRequest request = ar.AsyncState as WebRequest;
            var reponse = request.EndGetResponse(ar);
            var stream = request.GetRequestStream();
            using (StreamReader reader=new StreamReader(stream))
            {
                string str=reader.ReadLine();
            }
        }
        #endregion

        #region fileAsync
        //public delegate void ReturnEndEvent(object sender, ReturnEndReadEventargs args);
        //public event ReturnEndEvent IsReturnEvent;
        //INIT OR
        public event EventHandler<ReturnEndReadEventargs> IsReturnEvent;

        FileStream InputStream;
        StringBuilder ReadValue;
        byte[] buffer;
        public string ReadFileAsync(string fileName)
        {
            ReadValue = new StringBuilder();
            int BufferSize=0;
            buffer = new byte[BufferSize];

            InputStream = new FileStream(fileName, FileMode.Open, FileAccess.Read,
                FileShare.Read, BufferSize, useAsync: true);
            InputStream.BeginRead(buffer, 0, buffer.Length, OnCompleteRead, null);
            //InputStream.write
            return ReadValue.ToString();
        }

        public void OnCompleteRead(IAsyncResult asyncResult)
        {
            //异步读取一个快，接收数据
            int bytesRead = InputStream.EndRead(asyncResult);
            //如果没有任何字节，则流已达文件结尾
            if (bytesRead > 0)
            {
                //暂停以对模拟对数据块的处理
                Debug.WriteLine("异步线程：已读取一块内容");
                var datastr = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                ReadValue.Append(datastr);
                Thread.Sleep(TimeSpan.FromMilliseconds(20));
                //开始读取下一块
                InputStream.BeginRead(buffer, 0, buffer.Length, OnCompleteRead, null);
            }
            else
            {
                //操作结束
                Debug.WriteLine("   异步线程：读取文件结束");
                //event必须方法里调用
                OnIsReturnEvent();
            }
        }
        protected virtual void OnIsReturnEvent()
        {
            IsReturnEvent?.Invoke(this, new ReturnEndReadEventargs(true, ReadValue.ToString()));
            //IsReturnEvent(this, new ReturnEndReadEventargs(true, ReadValue.ToString()));
        }
        public class ReturnEndReadEventargs : EventArgs
        {
            public ReturnEndReadEventargs(bool isReturn, string value)
            {
                IsReturn = isReturn;
                ReadValue = value;
            }
            public string ReadValue { get; set; }
            public bool IsReturn { get; set; }
        }
        #endregion
    }
}
