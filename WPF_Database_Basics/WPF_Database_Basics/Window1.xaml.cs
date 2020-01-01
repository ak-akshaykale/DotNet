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
using System.Windows.Shapes;

namespace WPF_Database_Basics
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        SqlConnection con;

        DataSet ds;

        //Fill dataset
        private void BtnFill_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection();

            try
            {
                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Akshay;Integrated Security=True;Pooling=False";
                SqlCommand sqCom = new SqlCommand();
                sqCom.Connection = con;
                sqCom.CommandType = CommandType.Text;
                sqCom.CommandText = "select * from Employees";

                
                
                SqlDataAdapter sqDataAdapter = new SqlDataAdapter();
                sqDataAdapter.SelectCommand = sqCom;
                ds = new DataSet();
                int result = sqDataAdapter.Fill(ds, "Emps");
                MessageBox.Show(""+result);
                sqCom.CommandText = "select * from Departments";
                sqDataAdapter.SelectCommand = sqCom;

                sqDataAdapter.Fill(ds, "Depts");
                //Primary Key
                DataColumn[] dataColumns = new DataColumn[1];
                dataColumns[0] = ds.Tables["Emps"].Columns["EmpID"];
                ds.Tables["Emps"].PrimaryKey = dataColumns;
                //Foreign Key
                 ds.Relations.Add(ds.Tables["Depts"].Columns["DeptNo"], ds.Tables["Emps"].Columns["DeptNo"]);
                // dgEmps.Item

                //column Level Constraints
                ds.Tables["Emps"].Columns["Name"].AllowDBNull = false;


                dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Update dataset
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection();
            try
            {
                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Akshay;Integrated Security=True;Pooling=False";

                SqlCommand updateCommand = new SqlCommand();
                updateCommand.Connection = con;
                updateCommand.CommandType = CommandType.Text;
                updateCommand.CommandText = "update Employees set Name=@Name, Basic=@Basic, DeptNo=@DeptNo, EmpID=@EmpID_CUR where EmpID=@EmpID_ORI";
                updateCommand.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
                updateCommand.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
                updateCommand.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
                updateCommand.Parameters.Add(new SqlParameter { ParameterName = "@EmpID_CUR", SourceColumn = "EmpID", SourceVersion = DataRowVersion.Current });
                updateCommand.Parameters.Add(new SqlParameter { ParameterName = "@EmpID_ORI", SourceColumn = "EmpID", SourceVersion = DataRowVersion.Original });

                SqlDataAdapter updateDataAdapter = new SqlDataAdapter();
                updateDataAdapter.UpdateCommand = updateCommand;
                //updateDataAdapter.Update(ds, "Emps");
                

                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = con;
                insertCommand.CommandType = CommandType.Text;
                insertCommand.CommandText = "insert into Employees values(@EmpID,@Name,@DeptNo,@Basic)";
                insertCommand.Parameters.Add(new SqlParameter {
                    ParameterName="@EmpID",
                    SourceColumn="EmpID",
                    SourceVersion=DataRowVersion.Original
                });
                insertCommand.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Name",
                    SourceColumn = "Name",
                    SourceVersion = DataRowVersion.Current
                });
                insertCommand.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
                insertCommand.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
                updateDataAdapter.InsertCommand = insertCommand;



                SqlCommand deleteUpdate = new SqlCommand();
                deleteUpdate.Connection = con;
                deleteUpdate.CommandType = CommandType.Text;
                deleteUpdate.CommandText = "delete from Employees where EmpID=@EmpID";
                deleteUpdate.Parameters.Add(new SqlParameter { ParameterName="@EmpID",SourceColumn="EmpID",SourceVersion=DataRowVersion.Original});
                updateDataAdapter.DeleteCommand = deleteUpdate;

                updateDataAdapter.Update(ds, "Emps");
                MessageBox.Show("Records Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            ds.Tables["Emps"].DefaultView.RowFilter = "EmpID=" +txtFilter.Text ;
           
        }

        private void BtnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            ds.Tables["Emps"].DefaultView.RowFilter="";
            //dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView;
        }

        private void BtnXmlStore_Click(object sender, RoutedEventArgs e)
        {
            ds.WriteXmlSchema("Emp.xmd");
            ds.WriteXml("Emp.xml", XmlWriteMode.DiffGram);
            MessageBox.Show("Xml Saved");
        }

        private void BtnXmlRestore_Click(object sender, RoutedEventArgs e)
        {
            ds = new DataSet();
            ds.ReadXmlSchema("Emp.xmd");
            ds.ReadXml("Emp.xml");
            dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView;
            MessageBox.Show("Xml Restored");

        }
    }
}
