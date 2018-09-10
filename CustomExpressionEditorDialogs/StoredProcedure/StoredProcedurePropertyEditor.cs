using System;
using System.Activities.Presentation.PropertyEditing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomActivity
{
    class StoredProcedurePropertyEditor : DialogPropertyValueEditor
    {
        private ResourceDictionary res;
        //private FileEditorResources res = new FileEditorResources();

        public StoredProcedurePropertyEditor()
        {
            res = new ResourceDictionary();
            Console.WriteLine(Environment.CurrentDirectory);
            //res.Source = new Uri(@"D:\MainActionBuilderFinal\MainActionBuilder\ActionBuilder (2)\ActionBuilder\CustomActivity\CustomExpressionEditorDialogs\FileBrowserInlineEditorTemplate.xaml", UriKind.RelativeOrAbsolute);
            res.Source = new Uri("pack://application:,,,/CustomActivity;component/CustomExpressionEditorDialogs/FileBrowserInlineEditorTemplate.xaml");
            this.InlineEditorTemplate = res["FileBrowserInlineEditorTemplate"] as DataTemplate;
        }

        public override void ShowDialog(PropertyValue propertyValue, IInputElement commandSource)
        {
            StoredProcedureWindow storedProcedureWindow = new StoredProcedureWindow();
            //Reload the namespaces and the script in the custom editor dialog
            if ((System.Activities.InArgument<string>)propertyValue.Value != null)
            {
                //scriptPropertyWindow.EntireCode = ((System.Activities.Expressions.Literal<string>)((System.Activities.InArgument<string>)propertyValue.Value).Expression).Value;
            }
            storedProcedureWindow.ShowDialog();

            //if (storedProcedureWindow.DialogResult.HasValue && storedProcedureWindow++.DialogResult.Value)
            //{
            //    propertyValue.StringValue = scriptPropertyWindow.EntireCode;
            //}
            if (storedProcedureWindow.DialogResult.HasValue && storedProcedureWindow.DialogResult.Value)
            {
                
            }

        }
    }
}
