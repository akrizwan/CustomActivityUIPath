using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity
{
    [Designer(typeof(WebScriptEngineDesigner))]
    public class WebScriptEngine : NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> Script { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Process webAutomation = Process.Start(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\..\WebAutomation\bin\Debug\WebAutomation.exe"), Script.Get(context).Replace(" ","&nbsp;"));
        }
    }
}
