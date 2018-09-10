using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity
{
    [Designer(typeof(LogDesigner))]
    public class Log : NativeActivity
    {
        public InArgument<string> Type { get; set; }
        public InArgument<string> Description { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        [Editor(typeof(LogPropEditor), typeof(System.Activities.Presentation.PropertyEditing.DialogPropertyValueEditor))]
        public string Details { get; set; }
        protected override void Execute(NativeActivityContext context)
        {
            
        }
    }
}
