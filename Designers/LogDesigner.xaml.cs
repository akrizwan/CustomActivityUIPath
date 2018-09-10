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
    public partial class LogDesigner
    {
        public LogDesigner()
        {
            InitializeComponent();
        }
        private void ActivityDesigner_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void detailsBtn_Click(object sender, RoutedEventArgs e)
        {
            LogPropWindow logPropertyWindow = new LogPropWindow();
            Button button = sender as Button;
            DependencyObject g = button.Parent as DependencyObject;
            Grid parentGrid = g as Grid;
            TextBox detailsTextBox = parentGrid.Children[5] as TextBox;
            //Reload the namespaces and the script in the custom editor dialog
            if (detailsTextBox.Text != null)
            {
                logPropertyWindow.DetailsXML = detailsTextBox.Text;
            }
            logPropertyWindow.ShowDialog();

            if (logPropertyWindow.DialogResult.HasValue && logPropertyWindow.DialogResult.Value)
            {
                detailsTextBox.Text = logPropertyWindow.DetailsXML;
                detailsTextBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                detailsTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }
        }
    }
}
