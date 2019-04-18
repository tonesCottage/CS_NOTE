using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.泛型
{
    public class Event
    {
        #region TestSimpleEvent
        public delegate void FileUploadedHandler(int pro);
        //施加EVENT 受保护，避免直接使用FileUploadedHandler对象，来进行处理（必须在TestEvent内）
        //public event FileUploadedHandler fileUploaded_Test;
        public FileUploadedHandler fileUploaded;
        public void TestEvent()
        {
            int progress = 100;
            while (progress>0)
            {
                //trans
                progress--;
                //judge null; 
                //not null -----fileUploaded(progress)==fileUploaded.Invoke(progress)
                fileUploaded?.Invoke(progress);
            }
        }

        //Exist   //design  by IL
        //private class FileUploadedHandler : System.MulticastDelegate
        //{
        //    public FileUploadedHandler(object @object, IntPtr method) { }
        //    public virtual IAsyncResult BeginInvoke(int progress, AsyncCallback callback, Object @object)
        //    {
        //    }
        //    public virtual void EndInvoke()
        //    {
        //    }
        //    public virtual void Invoke(int progress)
        //    {
        //    }
        //}
        #endregion

        #region ChangeNormalEvent
        public class FileUploadedEventArgs : EventArgs
        {
            public int Progress { set; get; }
        }
        //remark: 委托名称以EventHandler结束，返回void,两个参数（sender,e事件参数），时间参数以EventArgs结尾

        //类外调用，使用+= -+=的形式
        public event EventHandler<FileUploadedEventArgs> FileUploaded_n;
        public void Upload()
        {
            FileUploadedEventArgs e = new FileUploadedEventArgs() { Progress = 100 };
            while (e.Progress>0)
            {
                e.Progress--;
                //if (fileUploaded_n!=null)
                //{
                //    fileUploaded_n(this, e);
                //}
                FileUploaded_n?.Invoke(this,e);
            }
        }
        #endregion
    }
}
