using System;
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
    // Interaction logic for SQLQueryDesigner.xaml
    public partial class SQLQueryDesigner
    {
        private List<GenericIntArguments> InputIntArguments { get; set; }
        private List<GenericStringArguments> InputStringArguments { get; set; }
        private List<GenericDecimalArguments> InputDecimalArguments { get; set; }

        private List<GenericIntArguments> OutputIntArguments { get; set; }
        private List<GenericStringArguments> OutputStringArguments { get; set; }
        private List<GenericDecimalArguments> OutputDecimalArguments { get; set; }

        private string Type_ { get; set; }

        public SQLQueryDesigner()
        {
            InitializeComponent();
        }

        private void SQLQueryActivity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemPlus)
            {
                NewInput newInput = new NewInput();
                newInput.Canceled = true;
                newInput.ShowDialog();

                if (newInput.Canceled == false)
                {

                    Type_ = newInput.Type;

                    if(Type_ == "System.String")
                    {
                        List<String> list = new List<string>();
                        list.Add(newInput.Value);

                        GenericStringArguments stringArguments = new GenericStringArguments
                        {
                            Name = newInput.InputName,
                            Type = Type_,
                            Value = list
                        };
                        InputStringArguments.Add(stringArguments);
                    }

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
