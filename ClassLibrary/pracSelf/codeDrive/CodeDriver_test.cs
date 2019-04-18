using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestReflect.Common.practice
{
    public class CodeDriver_test
    {

        //调用另外的程序集调用（每次使用都可以卸载）
        public string CompileAndRun(string input, out bool hasError)
        {
            AppDomain appdomain = AppDomain.CreateDomain("CodeDriver");
            CodeDriver codedriver = (CodeDriver)appdomain.CreateInstanceAndUnwrap("", "TestReflect.Common.practice.CodeDriver");
            string result = codedriver.CompileAndRun(input, out hasError);
            AppDomain.Unload(appdomain);
            return result;
        }
    }
}
