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

namespace CustomActivity
{
    /// <summary>
    /// Interaction logic for ScriptPropertyWindow.xaml
    /// </summary>
    public partial class ScriptPropertyWindow : Window
    {
        public string EntireCode { get; set; }

        public ScriptPropertyWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(EntireCode != null)
            {
                string pattern = @"using[\S\s]*namespace";
                var matches = Regex.Matches(EntireCode, pattern);
                txtNamespaces.Text = matches[0].Value.Replace("\nnamespace", "");

                var pattern1 = @"class CSharpClass\s*{[\s\S]*}[^\}]*}";
                var matches1 = Regex.Matches(EntireCode, pattern1);
                Match m1 = matches1[0];
                String script = m1.Value;
                script = Regex.Replace(script, @"class CSharpClass\s*{\s*", "");
                script = Regex.Replace(script, "\n\t\t", "\n");
                script = Regex.Replace(script, @"\s*}[^}]*}\z", "");
                txtScript.Text = script;
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            EntireCode = txtNamespaces.Text;

            EntireCode += "\nnamespace CSharpNamespace\n{\n\tclass CSharpClass\n\t{\n\t\t";
            EntireCode += txtScript.Text.Replace("\n", "\n\t\t");
            EntireCode += "\n\t}\n}";

            CSharpCoding.NameTypeDictionary = CSharpCoding.GetNameType(EntireCode);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
