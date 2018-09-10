using System;
using System.Activities;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
namespace CustomActivity
{
    [Activity]
    [Designer(typeof(CSharpDesigner))]
    public class CSharp:NativeActivity
    {
        public static Dictionary<string, string> NameTypeDictionary;

        public static Dictionary<string, string> GetNameType(string entireCode)
        {
            NameTypeDictionary = new Dictionary<string, string>();

            var matches = Regex.Matches(entireCode, @"\(.*\)");
            string allMethodParameters = matches[0].Value;
            string[] methodParameters = allMethodParameters.Substring(1,allMethodParameters.Length-2).Split(',');

            if (methodParameters[0] != "")
            {
                foreach (var item in methodParameters)
                {
                    string strTrim = item.Trim();
                    string[] nameTypeSplit = Regex.Split(strTrim, @"\s");

                    NameTypeDictionary.Add(nameTypeSplit[1], nameTypeSplit[0]);
                } 
            }
            return NameTypeDictionary;
        } 

        
        [DefaultValue(null)]
        [Editor(typeof(AssembliesPropertyEditor), typeof(System.Activities.Presentation.PropertyEditing.DialogPropertyValueEditor))]
        public InArgument<string> Assemblies { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        [Editor(typeof(ScriptPropEditor), typeof(System.Activities.Presentation.PropertyEditing.DialogPropertyValueEditor))]
        public string Script { get; set; }

        [DefaultValue(null)]
        //[Editor(typeof(MethodParametersEditor), typeof(System.Activities.Presentation.PropertyEditing.DialogPropertyValueEditor))]
        public InArgument<Object[]> MethodParameters { get; set; }


        public OutArgument<object> ReturnResult { get; set; }

        //public OutArgument<List<object>> ReturnResult2 { get; set; }



        protected override void Execute(NativeActivityContext context)
        {
            //1- Create code compiler for C# language
            CodeDomProvider _codeDomProvider = CodeDomProvider.CreateProvider("CSharp");
            string[] assemblySplit = null;
            //2- Fill compiler parameters
            if (Assemblies.Get(context)!=null)
            {
                assemblySplit = Assemblies.Get(context).Split(',');
            }
            
            CompilerParameters _compilerParameters = new CompilerParameters();
            if (assemblySplit!=null)
            {
                foreach (var item in assemblySplit)
                {
                    _compilerParameters.ReferencedAssemblies.Add(item);
                } 
            }

            _compilerParameters.GenerateExecutable = false;
            _compilerParameters.GenerateInMemory = true;

            //3- Compile the script
            CompilerResults _compilerResults = _codeDomProvider.CompileAssemblyFromSource(_compilerParameters, Script);

            //4- Check if compilation has errors
            if (_compilerResults.Errors.HasErrors)
            {
                string _errorMessage = "Compilation failed.\r\n";
                foreach (string _error in _compilerResults.Output)
                {
                    _errorMessage += _error + "\r\n";
                }

                MessageBox.Show(_errorMessage);
                return;
            }

            //5- Get the generated assembly
            Assembly _compiledAssembly = _compilerResults.CompiledAssembly;

            //Create an instace of the class that contains the script method
            //var _customScriptClassInstance = _compiledAssembly.CreateInstance(Namespace.Get(context)+"."+ClassName.Get(context));
            var _customScriptClassInstance = _compiledAssembly.CreateInstance("CSharpNamespace" + "." + "CSharpClass");

            //Get the Type info for the script class
            var _typeInfo = _customScriptClassInstance.GetType();

            //Get the method info that contains the script codes
            //var _methodInfo = _typeInfo.GetMethod(MethodName.Get(context));
            var pattern = @" [^ ]*[ \s\t]*\(";
            var matches = Regex.Matches(Script, pattern);
            Match m = matches[0];
            String methodName = m.Value.Substring(1, m.Value.Length - 2);
            methodName = Regex.Replace(methodName, @"[ \s\t]*", "");
            var _methodInfo = _typeInfo.GetMethod(methodName);

            //Invoke the method with the required parameters (pass null as the second parameter if method has no parameters)
            var oReturnValue = _methodInfo.Invoke(_customScriptClassInstance, MethodParameters.Get(context));

            ReturnResult.Set(context, oReturnValue);
            //Console.WriteLine(ReturnResult.Get(context).GetType().GetProperties());

            if (ReturnResult.Get(context) != null)
            {
                List<string> s = ReturnResult.Get(context) as List<string>;
                if (s != null)
                {
                    foreach (var item in s)
                    {
                        Console.WriteLine(item);
                    }  
                }
                else
                {
                    Console.WriteLine(ReturnResult.Get(context));
                }
            }
        }
    }
}