using Entities;
using System;
using System.Activities.Presentation.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomActivity
{
    // Interaction logic for SampleActivityDesigner.xaml
    public partial class SampleActivityDesigner
    {
        SampleActivity activity;
        List<Inputs> inputsList = new List<Inputs>();

        public SampleActivityDesigner()
        {
            InitializeComponent();

            activity = new SampleActivity();
        }

        private void ActivityDesigner_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.OemPlus)
            {
                NewInput newInput = new NewInput();
                newInput.Canceled = true;
                newInput.ShowDialog();

                if(newInput.Canceled == false)
                {
                    Inputs inputs = new Inputs
                    {
                        Name = newInput.InputName,
                        Type = Type.GetType(newInput.Type, true),
                        Value = newInput.Value
                    };

                    inputsList.Add(inputs);
                    ArrayList arr = new ArrayList() { "dfsf", "yjthty" };
                    ModelItem itemsarray = itemstextbox.Expression;
                    Console.WriteLine(   itemstextbox.DefaultValue);
                    string content = ((System.Windows.FrameworkElement)itemstextbox.Content).ToolTip.ToString();
                    content = content.Substring(0, content.Length - 1) + @""",hi""" + "}";
                    itemstextbox.DefaultValue=itemstextbox.DefaultValue.Substring(0,itemstextbox.DefaultValue.Length-1) + @""",hi""" + "}";
                    ((System.Windows.FrameworkElement)itemstextbox.Content).ToolTip = content;
                    TheGrid.RowDefinitions.Add(new RowDefinition());
                    var expressionTextBox = new System.Activities.Presentation.View.ExpressionTextBox();
                    TheGrid.Children.Add(expressionTextBox);
                    expressionTextBox.HintText = newInput.InputName;
                    Grid.SetRow(expressionTextBox, TheGrid.RowDefinitions.Count - 1);
                }
            }
        }
    }
}
