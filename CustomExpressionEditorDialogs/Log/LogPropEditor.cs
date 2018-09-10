using System;
using System.Activities.Presentation.PropertyEditing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomActivity
{
    class LogPropEditor : DialogPropertyValueEditor
    {
        private ResourceDictionary res;
        //private FileEditorResources res = new FileEditorResources();

        public LogPropEditor()
        {
            res = new ResourceDictionary();
            Console.WriteLine(Environment.CurrentDirectory);
            res.Source = new Uri("pack://application:,,,/CustomActivity;component/CustomExpressionEditorDialogs/FileBrowserInlineEditorTemplate.xaml");
            this.InlineEditorTemplate = res["FileBrowserInlineEditorTemplate"] as DataTemplate;
        }

        public override void ShowDialog(PropertyValue propertyValue, IInputElement commandSource)
        {
            LogPropWindow scriptPropertyWindow = new LogPropWindow();
            //Reload the namespaces and the script in the custom editor dialog
            if (propertyValue.Value != null)
            {
                scriptPropertyWindow.DetailsXML = propertyValue.Value.ToString();
            }
            scriptPropertyWindow.ShowDialog();

            if (scriptPropertyWindow.DialogResult.HasValue && scriptPropertyWindow.DialogResult.Value)
            {
                propertyValue.StringValue = scriptPropertyWindow.DetailsXML;
            }
        }
    }
}
