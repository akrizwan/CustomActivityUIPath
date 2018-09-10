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

namespace CustomActivity
{
    /// <summary>
    /// Interaction logic for MethodParametersWindow.xaml
    /// </summary>
    public partial class MethodParametersWindow : Window
    {
        List<TextBox> textBoxList = new List<TextBox>();

        public object[] ObjectList { get; set; }

        public MethodParametersWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int rowCount = 0;

            if(CSharpCoding.NameTypeDictionary.Count == 0)
            {
                Label noParameters = new Label();
                noParameters.Content = "Method has no parameters";
                noParameters.HorizontalAlignment = HorizontalAlignment.Center;

                methodParameterGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                Grid.SetColumn(noParameters, 0);
                Grid.SetRow(noParameters, 0);
                Grid.SetColumnSpan(noParameters, 2);

                methodParameterGrid.Children.Add(noParameters);

                rowCount++;
            }
            else
            {
                for (int i = 0; i < CSharpCoding.NameTypeDictionary.Count; i++)
                {
                    Label methodParameterName = new Label();
                    methodParameterName.Content = CSharpCoding.NameTypeDictionary.Keys.ElementAt(i) + "(" + CSharpCoding.NameTypeDictionary.Values.ElementAt(i) + "):";
                    methodParameterName.Margin = new Thickness(5);
                    TextBox methodParameterValue = new TextBox();
                    methodParameterValue.Margin = new Thickness(5);
                    textBoxList.Add(methodParameterValue);

                    methodParameterGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                    methodParameterGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                    Grid.SetColumn(methodParameterName, 0);
                    Grid.SetRow(methodParameterName, i);
                    Grid.SetColumn(methodParameterValue, 1);
                    Grid.SetRow(methodParameterValue, i);

                    methodParameterGrid.Children.Add(methodParameterName);
                    methodParameterGrid.Children.Add(methodParameterValue);

                    rowCount++;
                }
            }

            //Add an OK button at the end
            Button btnOK = new Button();
            btnOK.IsDefault = true;
            btnOK.Content = "OK";
            btnOK.HorizontalAlignment = HorizontalAlignment.Center;
            btnOK.Click += new RoutedEventHandler(btnOK_Click);
            Grid.SetColumn(btnOK, 0);
            Grid.SetRow(btnOK, rowCount);
            Grid.SetColumnSpan(btnOK, 2);

            methodParameterGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            methodParameterGrid.Children.Add(btnOK);
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            ObjectList = new object[textBoxList.Count];

            for (int i = 0; i < textBoxList.Count; i++)
            {
                ObjectList[i] = textBoxList[i].Text;
            }

            this.Close();
        }
    }
}
