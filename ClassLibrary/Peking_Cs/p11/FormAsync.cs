﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary.Peking_Cs.p11
{
    class FormAsync
    {
        //async private void button1_Click(object sender, EventArgs e)

        //{

        //    Console.WriteLine("BeforeGet" + Thread.CurrentThread.ManagedThreadId);

        //    this.textBox2.Text = "";

        //    string url = textBox1.Text.Trim();

        //    string content = await AccessTheWebAsync(url);

        //    this.textBox2.Text = content;

        //    Console.WriteLine("AfterGet" + Thread.CurrentThread.ManagedThreadId);



        //    Test();

        //}



        //// 在签名中三个要注意的事项: 

        ////  - 该方法具有一个async修饰符.  

        ////  - 返回类型为 Task or Task<t>. (参考 "返回类型" 一节.)

        ////    这里, 返回值是 Task<int> 因为返回的是一个整数类型. 

        ////  - 这个方法的名称以 "Async" 结尾.

        //async Task<string> AccessTheWebAsync(string url)

        //{

        //    // 你需要添加System.Net.Http的引用来声明client

        //    HttpClient client = new HttpClient();



        //    // GetStringAsync 返回 Task<string>. 这意味着当Task结束等待之后 

        //    // 你将得到一个string (urlContents).

        //    Task<string> getStringTask = client.GetStringAsync(url);



        //    // 你可以做一些不依赖于 GetStringAsync 返回值的操作.

        //    DoIndependentWork();



        //    // await 操作挂起了当前方法AccessTheWebAsync. 

        //    //  - AccessTheWebAsync 直到getStringTask完成后才会继续. 

        //    //  - 同时, 控制权将返回 AccessTheWebAsync 的调用者. 

        //    //  - 控制权会在getStringTask完成后归还到AccessTheAsync.  

        //    //  - await操作将取回getStringTask中返回的string结果. 

        //    string urlContents = await getStringTask;



        //    // return语句用来指定一个整数结果。

        //    // 调用AccessTheWebAsync将会收到一个返回值的长度. 

        //    return urlContents;

        //}





        //void DoIndependentWork()

        //{

        //    TextBox.Text += "Working . . . . . . .\r\n";

        //}
    }
}
