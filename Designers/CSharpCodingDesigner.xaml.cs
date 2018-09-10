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
    public partial class CSharpCodingDesigner
    {
        public CSharpCodingDesigner()
        {
            InitializeComponent();
        }

        private void ActivityDesigner_GotFocus(object sender, RoutedEventArgs e)
        {
            DataTemplate dataTemplate = FindResource("Expanded") as DataTemplate;

            ExpressionTextBox scriptBox = dataTemplate.FindName("scriptTextBox", CSharpCodingContentPresenter) as ExpressionTextBox;

            CSharpCoding.NameTypeDictionary = CSharpCoding.GetNameType(scriptBox.Expression.ToString());
        }
    }
}
