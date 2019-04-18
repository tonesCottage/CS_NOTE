using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TestReflect.Common.practice
{
    //根据字符串生成代码
    public class CodeDriver
    {
        private string prefix = "using System;" +
            "public static class Driver" +
            "{" +
            " public static void Run()" +
            " {";
        private string postfix =
            " }" +
            " }";
       
        public string CompileAndRun(string input, out bool hasError)
        {
           

            hasError = false;
            string returnData = null;

            CompilerResults results = null;
            using (var provider=new CSharpCodeProvider())
            {
                var options = new CompilerParameters();
                options.GenerateInMemory = true;

                var sb = new StringBuilder();
                sb.Append(prefix);
                sb.Append(input);
                sb.Append(postfix);

                results = provider.CompileAssemblyFromSource(options,sb.ToString());
            }

            if (results.Errors.HasErrors)
            {
                hasError = true;
                var errorMessage = new StringBuilder();
                foreach (CompilerError item in results.Errors)
                {
                    errorMessage.AppendFormat("{0}{1}", item.Line, item.ErrorText);
                }
                returnData = errorMessage.ToString();
            }
            else
            {
                TextWriter tw = Console.Out;
                var write = new StringWriter();
                Console.SetOut(write);
                Type driveType = results.CompiledAssembly.GetType("Driver");
                driveType.InvokeMember("Run", BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public, null, null, null);
                Console.SetOut(tw);

                returnData = write.ToString();
            }
            return returnData;
        }
    }
}
