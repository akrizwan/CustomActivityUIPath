using System;
using System.Activities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity
{
    [Designer(typeof(PowerShellScriptDesigner))]
    public class PowerShellScript: NativeActivity
    {
        [RequiredArgument]
        public InArgument<String> Script { get; set; }

        public OutArgument< Object> ReturnResult { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it

            runspace.Open();

            // create a pipeline and feed it the script text

            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(Script.Get(context));

            // add an extra command to transform the script
            // output objects into nicely formatted strings

            // remove this line to get the actual objects
            // that the script returns. For example, the script

            // "Get-Process" returns a collection
            // of System.Diagnostics.Process instances.

            //pipeline.Commands.Add("Out-String");

            // execute the script

            Collection <PSObject> results = pipeline.Invoke();

            // close the runspace

            runspace.Close();

            // convert the script result into a single string

            //StringBuilder stringBuilder = new StringBuilder();
            //foreach (PSObject obj in results)
            //{
            //    stringBuilder.AppendLine(obj.ToString());
            //}

            ReturnResult.Set(context, results[0]);
        }
    }
}
