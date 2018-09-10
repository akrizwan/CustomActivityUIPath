using System;
using System.Activities;
using System.Activities.Presentation.PropertyEditing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomActivity
{
    class MethodParametersEditor : DialogPropertyValueEditor
    {
        private ResourceDictionary res;
        //private FileEditorResources res = new FileEditorResources();

        public MethodParametersEditor()
        {
            res = new ResourceDictionary();
            Console.WriteLine(Environment.CurrentDirectory);
            //res.Source = new Uri(@"D:\MainActionBuilderFinal\MainActionBuilder\ActionBuilder (2)\ActionBuilder\CustomActivity\CustomExpressionEditorDialogs\FileBrowserInlineEditorTemplate.xaml", UriKind.RelativeOrAbsolute);
            res.Source = new Uri("pack://application:,,,/CustomActivity;component/CustomExpressionEditorDialogs/FileBrowserInlineEditorTemplate.xaml");
            this.InlineEditorTemplate = res["FileBrowserInlineEditorTemplate"] as DataTemplate;
        }

        public override void ShowDialog(PropertyValue propertyValue, IInputElement commandSource)
        {
            MethodParametersWindow methodParametersWindow = new MethodParametersWindow();
            methodParametersWindow.ShowDialog();

            propertyValue.Value = new InArgument<Object[]>((methodParametersWindow.ObjectList));

            //((System.Activities.InArgument<object[]>)propertyValue.Value).Expression = methodParametersWindow.ObjectList;
        }
    }
}
