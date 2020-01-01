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

namespace LoginValidation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Akshay;Integrated Security=True;Pooling=False";
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                con.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "select Uid from DbUser where Uid=@UID and Pwd=@PWD";
                command.Parameters.AddWithValue("@UID", txtUid.Text);
                command.Parameters.AddWithValue("@PWD", txtPwd.Password);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    MessageBox.Show("Congrats.!");
                    Home h = new Home();
                    h.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid");
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUid.Text = "";
            txtPwd.Password = "";
        }
    }
}
