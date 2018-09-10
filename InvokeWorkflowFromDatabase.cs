using System;
using System.Activities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowBLL;
using Entities;
using System.Xaml;
using System.Activities.XamlIntegration;
using System.IO;
using System.Activities.Statements;

namespace CustomActivity
{
    [Designer(typeof(InvokeWorkflowFromDatabaseDesigner))]
    public class InvokeWorkflowFromDatabase : NativeActivity
    {
        [DefaultValue(null)]
        public InArgument<IDictionary<string,object>> Input { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> Activity { get; set; }

        public OutArgument<IDictionary<string, object>> Output { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            BLL bll = new BLL();
            ArrayList a=bll.GetActivityDetailsByID(Activity.Get(context));
            Activit activit = a[0] as Activit;
            Activity_Content activity_Content = a[1] as Activity_Content;
            
            // Create a new ActivityBuilder and initialize it using the serialized
            // workflow definition.
            //ActivityBuilder ab = XamlServices.Load(
            //    ActivityXamlServices.CreateBuilderReader(
            //    new XamlXmlReader(new StringReader(activity_Content.ActivityContent)))) as ActivityBuilder;

            var dynamicActivity = ActivityXamlServices.Load(new StringReader(activity_Content.ActivityContent)) as DynamicActivity;

            IDictionary<string, object> outputlst = WorkflowInvoker.Invoke(dynamicActivity, Input.Get(context));
            Output.Set(context, outputlst);
        }
    }
}
