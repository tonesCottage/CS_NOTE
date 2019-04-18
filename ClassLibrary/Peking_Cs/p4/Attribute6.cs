using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Peking_Cs.p4
{
    [AttributeUsage(AttributeTargets.Class
     | AttributeTargets.Method,
     AllowMultiple = true)]
    public class HelpAttribute : System.Attribute
    {
        public readonly string Url;
        private string topic;
        public string Topic      // 属性 Topic 是命名参数
        {
            get
            {
                return topic;
            }
            set
            {
                topic = value;
            }
        }
        public HelpAttribute(string url)  // url 是位置参数
        {
            this.Url = url;
        }
    }

    [HelpAttribute("https://msvc/MyClassInfo", Topic = "Test"),
    Help("https://my.com/about/class")]
    class MyClass
    {
        [Help("http;//my.com/about/method")]
        public void MyMethod(int i)
        {
            return;
        }
    }

    public class MemberInfo_GetCustomAttributes
    {
        public static void Main()
        {
            Type myType = typeof(MyClass);

            object[] attributes = myType.GetCustomAttributes(false);
            for (int i = 0; i < attributes.Length; i++)
            {
                PrintAttributeInfo(attributes[i]);
            }

            MemberInfo[] myMembers = myType.GetMembers();
            for (int i = 0; i < myMembers.Length; i++)
            {
                Console.WriteLine("\nNumber {0}: ", myMembers[i]);
                Object[] myAttributes = myMembers[i].GetCustomAttributes(false);
                for (int j = 0; j < myAttributes.Length; j++)
                {
                    PrintAttributeInfo(myAttributes[j]);
                }
            }
        }

        static void PrintAttributeInfo(object attr)
        {
            if (attr is HelpAttribute)
            {
                HelpAttribute attrh = (HelpAttribute)attr;
                Console.WriteLine("----Url: " + attrh.Url + "  Topic: " + attrh.Topic);
            }
        }
    }
    class Attribute6
    {
    }
}
