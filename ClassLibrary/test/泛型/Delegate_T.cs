using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.泛型
{
    public class Delegate_T
    {
        //fun
        delegate int AddHander(int i, int j);
        //action
        delegate void Print(string msg);
        #region simpleDelegate
        public int Add(int i,int j)
        {
            return i + j;
        }
        public void print(string s)
        {
            Console.Write(s);
        }
        //main function
        public void Show1()
        {
            AddHander add = Add;
            Print pr = print;
        }
        #endregion
        #region FunAndAction//predicate
        public void Show2()
        {
            Func<int, int, int> add = Add;
            Action<string> pr = print;
            pr(add(1, 2).ToString());
        }
        public void Show3()
        {
            Func<int, int, int> add = new Func<int, int, int>(Add);
            Action<string> pr = new Action<string>(print);
            pr(add(1, 2).ToString());
        }
        //anonymity function
        public void Show4()
        {
            Func<int, int, int> add = new Func<int, int, int>(delegate(int i,int j) {
                return i + j;
            });
            Action<string> pr = new Action<string>(delegate(string s) {
                Console.Write(s);
            });
            pr(add(1, 2).ToString());
        }
        //lambda
        public void Show5()
        {
            Func<int, int, int> add = new Func<int, int, int>((i,j)=> {
                return i + j;
            });
            Action<string> pr = new Action<string>((s)=> {
                Console.Write(s);
            });
            pr(add(1, 2).ToString());
        }
        #endregion
        #region LamdbaTest
        class Student
        {
            public string name { set; get; }
        }
        public void test01()
        {
            List<Student> list = new List<Student>();
            //var lists= list.Where(target=> target.name="sss");
            var li = from s in list where s.name == "ss" select s;
            list.Find(target =>
            {
                target.name = "ss";
                return true;
            });
        }
        #endregion

        #region OtherDelegate
        //register event  fuction
        delegate void EventHandler(object sender,EventArgs e);
        delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
        //Thread
        delegate void ThreadStart();
        delegate void ParameterizedThreadStart(object obj);
        //Async Callback
        delegate void AsyncCallback(IAsyncResult ar);
        #endregion
}
}
