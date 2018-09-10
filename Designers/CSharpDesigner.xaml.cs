using System;
using System.Activities;
using System.Activities.Presentation.View;
using System.Collections.Generic;
using System.Data;
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
    public partial class CSharpDesigner
    {
        public CSharpDesigner()
        {
            InitializeComponent();
        }

        private void ActivityDesigner_GotFocus(object sender, RoutedEventArgs e)
        {
            DataTemplate dataTemplate = FindResource("Expanded") as DataTemplate;

            TextBox scriptBox = dataTemplate.FindName("scriptTextBox", CSharpCodingContentPresenter) as TextBox;

            CSharp.NameTypeDictionary = CSharp.GetNameType(scriptBox.Text.ToString());
        }
    }
}
