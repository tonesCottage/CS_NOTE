using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestReflect.Common.practice
{
    class codedom_test
    {
        
        public string GenerateCode(CodeCompileUnit unit, string language)
        {
            StringBuilder sb = new StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter();
            CodeDomProvider.CreateProvider(language).GenerateCodeFromCompileUnit
            (unit, sw, null);
            sw.Close();
            return sw.ToString();
        }
        public CompilerResults CompilerCode(CodeCompileUnit unit, string language)
        {
            CompilerParameters option = new CompilerParameters();
            option.GenerateExecutable = true;
            option.GenerateInMemory = false;
            option.IncludeDebugInformation = true;
            option.ReferencedAssemblies.Add("System.dll");
            option.OutputAssembly = "Demo5.exe";
            return CodeDomProvider.CreateProvider(language).CompileAssemblyFromDom
            (option, unit);
        }
        public CodeCompileUnit CodeDomHelloDemo()
        {
            //Mehtod
            CodeEntryPointMethod method = new CodeEntryPointMethod();
            //Console.WriteLine("Hello Word!");
            CodeMethodInvokeExpression methodWrite = new CodeMethodInvokeExpression(
            new CodeTypeReferenceExpression(typeof(Console)), "WriteLine",
            new CodePrimitiveExpression("Hello Word!"));
            //Console.Read();
            CodeMethodInvokeExpression methodread = new CodeMethodInvokeExpression(
            new CodeTypeReferenceExpression(typeof(Console)), "Read");
            method.Statements.Add(methodWrite);
            method.Statements.Add(methodread);
            //class Hello
            CodeTypeDeclaration hello = new CodeTypeDeclaration("Hello");
            hello.Attributes = MemberAttributes.Public;
            hello.Members.Add(method);
            //namespace Demo5
            CodeNamespace nspace = new CodeNamespace("Demo5");
            nspace.Imports.Add(new CodeNamespaceImport("System"));
            nspace.Types.Add(hello);
            //CodeCompileUnit
            CodeCompileUnit unit = new CodeCompileUnit();
            unit.Namespaces.Add(nspace);
            return unit;
        }
    }
}
