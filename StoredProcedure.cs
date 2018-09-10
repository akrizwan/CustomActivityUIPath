using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity
{
    public class StoredProcedure : NativeActivity
    {
        public static string connectionString;

        [RequiredArgument]
        public InArgument<string> ConnectionString { get; set; }

        [RequiredArgument]
        [Editor(typeof(StoredProcedurePropertyEditor), typeof(System.Activities.Presentation.PropertyEditing.DialogPropertyValueEditor))]
        public InArgument<string> ProcedureParameters { get; set; }
        protected override void Execute(NativeActivityContext context)
        {
            
            //SqlCommandBuilder;
        }
    }
}
