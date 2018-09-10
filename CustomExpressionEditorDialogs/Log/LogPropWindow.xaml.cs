using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml;

namespace CustomActivity
{
    /// <summary>
    /// Interaction logic for ScriptPropertyWindow.xaml
    /// </summary>
    public partial class LogPropWindow : Window
    {
        public string DetailsXML { get; set; }

        public LogPropWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(DetailsXML!=null)
            {
                txtDetails.Text = DetailsXML;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(txtDetails.Text);


            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            DetailsXML = txtDetails.Text;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
