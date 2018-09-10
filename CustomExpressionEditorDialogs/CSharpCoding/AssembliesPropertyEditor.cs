using System;
using System.Activities.Presentation.PropertyEditing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomActivity
{
    class AssembliesPropertyEditor: DialogPropertyValueEditor
    {
        private ResourceDictionary res;
        //private FileEditorResources res = new FileEditorResources();

        public AssembliesPropertyEditor()
        {
            res = new ResourceDictionary();
            Console.WriteLine(Environment.CurrentDirectory);
            //res.Source = new Uri(@"D:\MainActionBuilderFinal\MainActionBuilder\ActionBuilder (2)\ActionBuilder\CustomActivity\CustomExpressionEditorDialogs\FileBrowserInlineEditorTemplate.xaml", UriKind.RelativeOrAbsolute);
            res.Source = new Uri("pack://application:,,,/CustomActivity;component/CustomExpressionEditorDialogs/FileBrowserInlineEditorTemplate.xaml");
            this.InlineEditorTemplate = res["FileBrowserInlineEditorTemplate"] as DataTemplate;
        }

        public override void ShowDialog(PropertyValue propertyValue, IInputElement commandSource)
        {
            AssembliesPropertyWindow assembliesPropertyWindow = new AssembliesPropertyWindow();
            //Reloading the list of assemblies that are already chosen
            if ((System.Activities.InArgument<string>)propertyValue.Value != null)
            {
                string[] assemblySplit = ((System.Activities.Expressions.Literal<string>)((System.Activities.InArgument<string>)propertyValue.Value).Expression).Value.Split(',');
                assembliesPropertyWindow.SelectedAssemblyList = new List<string>();
                foreach (var item in assemblySplit)
                {
                    assembliesPropertyWindow.SelectedAssemblyList.Add(item);
                }
            }
            assembliesPropertyWindow.ShowDialog();

            if(assembliesPropertyWindow.DialogResult.HasValue && assembliesPropertyWindow.DialogResult.Value)
            {
                string[] arrAssembly = assembliesPropertyWindow.SelectedAssemblyList.ToArray();
                propertyValue.StringValue = String.Join(",", arrAssembly);
            }
        }
    }
}
