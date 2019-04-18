using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test.test.ThreadT
{
    public class ThreadTest
    {
        public void testTask()
        {
            Task t = new Task(() =>
            {
                while (true)
                {
                }
            });
            t.ContinueWith((task) =>
            {
                try
                {
                    task.Wait();
                }
                catch (AggregateException ex)
                {
                    foreach (Exception item in ex.InnerExceptions)
                    {

                    }
                }
            },TaskContinuationOptions.OnlyOnFaulted);
            t.Start();
        }

        #region MyRegion
        //WaitHandle(EventWaitHandle:AutoResetEvent,ManualResetEvent;Semaphore;Mutex)
        //给出阻滞状态。给出信号后自己回到阻滞
        private AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        public void Test1()
        {
            Thread TH = new Thread(()=> {
                //DO  SOMETHING
                bool re=autoResetEvent.WaitOne();
                //CONTINUE DOING
            });

        }
        public void Test2()
        {
            //给等待的线程一个信号
            autoResetEvent.Set();
        }
        #endregion

    }
}
