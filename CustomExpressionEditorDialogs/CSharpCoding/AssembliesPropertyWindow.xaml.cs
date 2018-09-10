using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomActivity
{
    /// <summary>
    /// Interaction logic for AssembliesProperty.xaml
    /// </summary>
    public partial class AssembliesPropertyWindow : Window
    {
        public List<string> SelectedAssemblyList { get; set; }

        public AssembliesPropertyWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(SelectedAssemblyList != null)
            {
                foreach (var item in SelectedAssemblyList)
                {
                    ListBoxItem listBoxItem = new ListBoxItem();
                    listBoxItem.Content = item;

                    lstAssemblies.Items.Add(listBoxItem);
                }
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            SelectedAssemblyList = new List<string>();
            foreach (var item in lstAssemblies.Items)
            {
                SelectedAssemblyList.Add(((System.Windows.Controls.ContentControl)item).Content.ToString());
            }
 
            DialogResult = true;
        }

        private void btnAddGACAssembly_Click(object sender, RoutedEventArgs e)
        {
            AddGACAssemblyWindow addGACAssemblyWindow = new AddGACAssemblyWindow();
            addGACAssemblyWindow.ShowDialog();

            //lstAssemblies.ItemsSource = addGACAssemblyWindow.GACAssemblyList;

            foreach (var item in addGACAssemblyWindow.GACAssemblyList)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = ((System.Windows.Controls.ContentControl)item).Content.ToString();

                lstAssemblies.Items.Add(itm);
            }
        }

        private void btnRemoveAssembly_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lstAssemblies.SelectedItems)
            {
                lstAssemblies.Items.Remove(item);
            }
            lstAssemblies.Items.Refresh();
        }
    }
}
