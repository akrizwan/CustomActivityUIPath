using System;
using System.Collections.Generic;
using System.IO;
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
//using System.Windows.Shapes;

namespace CustomActivity
{
    /// <summary>
    /// Interaction logic for AddGACAssemblyWindow.xaml
    /// </summary>
    public partial class AddGACAssemblyWindow : Window
    {
        public List<object> GACAssemblyList { get; set; }

        public AddGACAssemblyWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> gacFolders = new List<string>() {
                    "GAC", "GAC_32", "GAC_64", "GAC_MSIL",
                    "NativeImages_v2.0.50727_32",
                    "NativeImages_v2.0.50727_64",
                    "NativeImages_v4.0.30319_32",
                    "NativeImages_v4.0.30319_64"
                };

            foreach (string folder in gacFolders)
            {
                string path = Path.Combine(
                   Environment.ExpandEnvironmentVariables(@"%systemroot%\assembly"),
                   folder);

                if (Directory.Exists(path))
                {
                    Console.WriteLine("<hr/>" + folder + "<br/>");

                    string[] assemblyFolders = Directory.GetDirectories(path);
                    foreach (string assemblyFolder in assemblyFolders)
                    {

                        Console.WriteLine(assemblyFolder + "<br/>");

                        //Split the string and extract the last string to get the assembly name
                        string[] assemblyPath = assemblyFolder.Split('\\');
                        string assemblyName = assemblyPath[assemblyPath.Length - 1];
                        //Create ListBox Item for each assembly
                        ListBoxItem listBoxItem = new ListBoxItem();
                        listBoxItem.Content = assemblyName + ".dll";

                        lstGACAssemblies.Items.Add(listBoxItem);
                    }
                }
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            GACAssemblyList = new List<object>();
            foreach (var item in lstGACAssemblies.SelectedItems)
            {
                GACAssemblyList.Add(item);
            }
            this.Close();
        }
    }
}
