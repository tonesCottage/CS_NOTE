using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace ClassLibrary.Peking_Cs.p11
{
    class Async_HttpClientT
    {
        int tasks = 10;

        Queue<string> results = new Queue<string>();

        string baseUrl = "https://www.pku.edu.cn";

        public void Start()

        {

            Task[] tasks = new Task[this.tasks];



            for (int i = 0; i < this.tasks; ++i)

            {

                tasks[i] = this.Perform(i);

            }



            Task.WaitAll(tasks);



            results.ToList().ForEach(Console.WriteLine);

        }

        public async Task Perform(int state)

        {

            string url = String.Format("{0}{1}", this.baseUrl, state.ToString().PadLeft(3, '0'));
            var client = new HttpClient();
            //var client = new TcpClient();

            Stopwatch timer = new Stopwatch();



            timer.Start();
            //IPAddress iPAddress = new IPAddress(url);
            string result = await client.GetStringAsync(url);
            //string result = await client.ConnectAsync(iPAddress,80);

            timer.Stop();



            //this.results.Enqueue(String.Format("{0,4}\t{1,5}\t{2}", url, timer.ElapsedMilliseconds, result));

        }
    }
}
