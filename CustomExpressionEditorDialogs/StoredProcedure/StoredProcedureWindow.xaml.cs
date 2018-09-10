using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for StoredProcedureWindow.xaml
    /// </summary>
    public partial class StoredProcedureWindow : Window
    {
        List<TextBox> textBoxList = new List<TextBox>();
        List<ProcedureParameters> procedureParametersList = new List<ProcedureParameters>();
        public StoredProcedureWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void btnFetchParameters_Click(object sender, RoutedEventArgs e)
        {
            //SqlCommandBuilder.DeriveParameters(myCommand);
            SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = StoredProcedure.connectionString;
            connection.ConnectionString = "Network Library=DBMSSOCN;Data Source=10.6.14.136,1433;Initial Catalog=OneAutomation;User Id=FlxAdmin;Password=FlxAdmin;";
            connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = txtStoredProcedureName.Text;
            myCommand.Connection = connection;
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(myCommand);
            connection.Close();

            for (int i = 0; i < myCommand.Parameters.Count; i++)
            {
                if (myCommand.Parameters[i].Direction== ParameterDirection.Input || myCommand.Parameters[i].Direction == ParameterDirection.InputOutput)
                {
                    procedureParametersList.Add(new ProcedureParameters { dbType = myCommand.Parameters[i].DbType, Name = myCommand.Parameters[i].ParameterName });
                    Label methodParameterName = new Label();
                    methodParameterName.Content = myCommand.Parameters[i].ParameterName;
                    methodParameterName.Margin = new Thickness(5);
                    TextBox methodParameterValue = new TextBox();
                    methodParameterValue.Margin = new Thickness(5);
                    textBoxList.Add(methodParameterValue);

                    procedureParameterGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                    procedureParameterGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                    Grid.SetColumn(methodParameterName, 0);
                    Grid.SetRow(methodParameterName, i);
                    Grid.SetColumn(methodParameterValue, 1);
                    Grid.SetRow(methodParameterValue, i);

                    procedureParameterGrid.Children.Add(methodParameterName);
                    procedureParameterGrid.Children.Add(methodParameterValue); 
                }

                //rowCount++;
            }

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < procedureParametersList.Count; i++)
            {
                procedureParametersList.ElementAt(i).Value = textBoxList[i].Text;
            }

            this.Close();
        }
    }
}
