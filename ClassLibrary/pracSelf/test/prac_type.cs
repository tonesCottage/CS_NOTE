using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransmission.practice
{
    public class prac_type
    {
        public enum TimeOfDay
        {
            morning=0,
            Afternoon=1,
            evening=2
        }
        public bool TestRe(int value,int a)
        {
            if (value == 0)
                return true;
            return false;
        }

        public static void main(string[] strs)
        {
            prac_type pt = new prac_type();
            bool a= pt.TestRe(a:1,value:2);

            //弱引用
            WeakReference WR = new WeakReference(new prac_type());
            prac_type prt=WR.Target as prac_type;

            //

        }

        public void test()
        {
            Queue<string> que = new Queue<string>();
            Stack<string> sta = new Stack<string>();

            LinkedList<string> lin = new LinkedList<string>();
            LinkedListNode<string> lln= lin.First;
            LinkedListNode<string> ln = lln.Next;

            SortedList<string,string> sor = new SortedList<string,string>();
            sor.Add("today", "今天");
            sor.Add("tomorrow","明天");
            IList<string> listk=sor.Keys;
            IList<string> listv = sor.Values;
            foreach (KeyValuePair<string,string> item in sor)
            {
            }



        }
    }
        
}
