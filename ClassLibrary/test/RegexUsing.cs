using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Test.test
{
    public class RegexUsing
    {
        //Regex.IsMatch();//用来判断给定的字符串是否匹配某个正则表达式
        //Regex.Match();//用来从给定的字符串中按照正则表达式的要求提取【一个】匹配的字符串
        //Regex.Matches();//用来从给定的字符串中按照正则表达式的要求提取【所有】匹配的字符串
        //Regex.Replace(); //替换所有正则表达式匹配的字符串为另外一个字符串。

        //regex regulation
        //1.  10-25的数字           "^(1[0-9]|2[0-5])$"
        //2.  手机号（11位数字）    @"^\d{11}$"              URL：      @"^[a-zA-Z0-9]+://.+$ 
        //3.  身份证号              "^[1-9]\d{16}[0-9xX]|[1-9]\d{14}$"
        //4.  email                 @"^[-0-9a-zA-Z_\.]+@[a-zA-Z0-9]+(\.[a-zA-Z]+){1,2}$"
        //5.  ip地址                @"^([0-9]{1,3}\.){3}[0-9]{1,3}$"     日期  @"^[0-9]{4}-[0-9]{2}-[0-9]{2}$
        public void Test()
        {
            string msg = "大家好呀，hello,2010年10月10日是个好日子。恩，9494.吼吼！886.";
            Match match = Regex.Match(msg, "[0-9]+");
            string value = match.Value;
            MatchCollection matches = Regex.Matches(msg, "[0-9]+");
        }
        public void ReplaceStr()
        {
            //将hello ‘welcome’ to ‘China’   替换成 hello 【welcome】 to 【China】
            string msg1 = "hello 'welcome' to 'China'  'lss'   'ls'   'szj'   ";
            msg1 = Regex.Replace(msg1, @"'(.+?)'", "【$1】");//2个$$代表一个，转义了

            string msg2 = "你们喜欢XXXXXYYYYYYZZZZZZZ";
            msg2 = Regex.Replace(msg2, @"(.)\1+", "$1");//Replace最后一个参数还可以对我们输入的正则进行操作

            string msg3 = "xxx13409876543yyy18276354908aa87654321345bb98761234654";
            msg3 = Regex.Replace(msg3, @"([0-9]{3})[0-9]{4}([0-9]{4})", "****$2");

        }
    }
}
