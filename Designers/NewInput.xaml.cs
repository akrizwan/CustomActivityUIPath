using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.Input;
using Telerik.Windows.Data;

namespace CustomActivity
{
    /// <summary>
    /// Interaction logic for NewInput.xaml
    /// </summary>
    public partial class NewInput : Window
    {
        public NewInput()
        {
            InitializeComponent();
        }

        public bool Canceled { get; set; }

        public string InputName
        {
            get { return nameTextBox.Text; }
        }

        public string Type
        {
            get { return typeTextBox.Text; }
        }

        public string Value
        {
            get { return valueTextBox.Text; }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Canceled = false;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Canceled = true;
            Close();
        }
    }
}
