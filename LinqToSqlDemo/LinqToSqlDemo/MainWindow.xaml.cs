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

namespace LinqToSqlDemo
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

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataClass1DataContext dataContext = new DataClass1DataContext();
            Employee employee = new Employee();
            try
            {
                employee.EmpID = Convert.ToInt32( txtEmpID.Text);
                employee.Name = txtName.Text;
                employee.DeptNo = Convert.ToInt32(txtDeptNo.Text);
                employee.Basic = Convert.ToDecimal(txtBasic.Text);

                dataContext.Employees.InsertOnSubmit(employee);
                dataContext.SubmitChanges();
                MessageBox.Show("Record Inserted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            //dataContext.Employees.AsEnumerable();
            //var emps =from emp in Employee emp.
        }
        DataClass1DataContext dc1 = new DataClass1DataContext();
        Employee employee;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            employee = dc1.Employees.SingleOrDefault(emp1 => emp1.EmpID == Convert.ToInt32(txtEmpID.Text));

            try
            {
                employee.Name = txtName.Text;
                employee.DeptNo = Convert.ToInt32(txtDeptNo.Text);
                employee.Basic = Convert.ToDecimal(txtBasic.Text);

                dc1.SubmitChanges();
                MessageBox.Show("Record Updated");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            employee= dc1.Employees.SingleOrDefault(emp1 => emp1.EmpID == Convert.ToInt32(txtEmpID.Text));
            if (employee != null)
            {
                txtEmpID.Text = "" + employee.EmpID;
                txtName.Text = employee.Name;
                txtDeptNo.Text = "" + employee.DeptNo;
                txtBasic.Text = "" + employee.Basic;
            }
            else
            {
                MessageBox.Show("EmpID Not Found");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            employee = dc1.Employees.SingleOrDefault(emp1 => emp1.EmpID == Convert.ToInt32(txtEmpID.Text));

            try
            {
                dc1.Employees.DeleteOnSubmit(employee);
                dc1.SubmitChanges();
                MessageBox.Show("Record Deleted");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            txtEmpID.Text = "";
            txtName.Text = "";
            txtDeptNo.Text = "";
            txtBasic.Text = "";
        }
    }
}
