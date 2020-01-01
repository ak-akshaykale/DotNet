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
using System.Xml;

namespace WPF_Database_Basics
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

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Akshay;Integrated Security=True";
                //con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Akshay;Integrated Security=True;Pooling=False";
                con.Open();
                SqlCommand scmd = new SqlCommand();
                scmd.Connection = con;

                scmd.CommandType = CommandType.Text;
                scmd.CommandText = "insert into Employees values("+txtEmpID.Text+",'"+txtName.Text+"',"+txtDeptNo.Text+","+txtBasic.Text+")";
               // 46545); delete from Employees where 1 = 1)"
                int resut = scmd.ExecuteNonQuery();
                MessageBox.Show(resut+" Record Inserted");
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Akshay;Integrated Security=True";
                con.Open();

                SqlCommand scom = new SqlCommand();
                scom.Connection = con;

                scom.CommandType = CommandType.Text;
                scom.CommandText = "insert into Employees values(@EmpID,@Name,@DeptNo,@Basic)";
                scom.Parameters.AddWithValue("@EmpID", txtEmpID.Text);
                scom.Parameters.AddWithValue("@Name", txtName.Text);
                scom.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);
                scom.Parameters.AddWithValue("@Basic", txtBasic.Text);

                int result = scom.ExecuteNonQuery();
                MessageBox.Show(result + " Record Inserted ");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Akshay;Integrated Security=True"; ;
                con.Open();
                SqlCommand scom = new SqlCommand();
                scom.Connection = con;
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "InsertEmployee";
                scom.Parameters.AddWithValue("@EmpID",txtEmpID.Text);
                scom.Parameters.AddWithValue("@Name",txtName.Text);
                scom.Parameters.AddWithValue("@DeptNo",txtDeptNo.Text);
                scom.Parameters.AddWithValue("@Basic",txtBasic.Text);
                scom.ExecuteNonQuery();
                MessageBox.Show("Record Inserted..");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Transaction
            SqlConnection con = new SqlConnection();
            con.ConnectionString= @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Akshay;Integrated Security=True";
            con.Open();

            SqlCommand scom = new SqlCommand();
            scom.Connection = con;
            SqlTransaction tran = con.BeginTransaction();
            scom.Transaction = tran;
            try
            {
                scom.CommandType = CommandType.Text;
                scom.CommandText = "insert into Employees values(" + txtEmpID.Text + ",'" + txtName.Text + "'," + txtDeptNo.Text + "," + txtBasic.Text + ")";
                //scom.Parameters.AddWithValue() @Columnval
                scom.ExecuteNonQuery();

                scom.CommandText = "insert into Employees values(11,'" + txtName.Text + "'," + txtDeptNo.Text + "," + txtBasic.Text + ")";
                scom.ExecuteNonQuery();
                tran.Commit();
                MessageBox.Show("Commit");
            }
            catch (Exception ee)
            {
                MessageBox.Show("RollBack");
                tran.Rollback();
                MessageBox.Show(ee.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Akshay;Integrated Security=True";
                con.Open();

                SqlCommand scom = new SqlCommand();
                scom.Connection = con;

                scom.CommandType = CommandType.Text;
                scom.CommandText = "select * from Employees";

                SqlDataReader  dr =scom.ExecuteReader();
                //MessageBox.Show();
                /* xreader.Read();
                // MessageBox.Show(xreader.GetAttribute("EmpID"));
                 //+" " + xreader["Name"] + " " + xreader["DeptNo"] + " " + xreader["Basic"]*/
                 while (dr.Read())
                 {
                    MessageBox.Show(""+dr);
                    //txtEmpID.Text = ;
                  //  dr.get
                    // MessageBox.Show(xreader.GetAttribute("EmpID"));
                 }
                //
            }
            catch (Exception ee)
            {
                MessageBox.Show("dsdd "+ee.Message);
            }
        }

        private void BtnSwitch_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
            this.Close();


        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TypedDataset td = new TypedDataset();
            td.Show();
            this.Close();
        }
    }
}
