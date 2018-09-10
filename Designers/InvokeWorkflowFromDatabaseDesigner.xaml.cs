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
using WorkflowBLL;
using Entities;

namespace CustomActivity
{
    // Interaction logic for InvokeWorkflowFromDatabase.xaml
    public partial class InvokeWorkflowFromDatabaseDesigner
    {
        BLL bll = new BLL();

        public InvokeWorkflowFromDatabaseDesigner()
        {
            InitializeComponent();
        }

        private void ActivityDesigner_Loaded(object sender, RoutedEventArgs e)
        {
            List<ActivityDetails> activityList = bll.GetActivityList();

            foreach (var item in activityList)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = item.Activity_Name;
                activityNameComboBox.Items.Add(comboBoxItem);
            }
        }
    }
}
