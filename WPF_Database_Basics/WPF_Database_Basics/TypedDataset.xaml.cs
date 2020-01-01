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
using System.Windows.Shapes;
using WPF_Database_Basics.MyDataSetTableAdapters;

namespace WPF_Database_Basics
{
    /// <summary>
    /// Interaction logic for TypedDataset.xaml
    /// </summary>
    public partial class TypedDataset : Window
    {
        public TypedDataset()
        {
            InitializeComponent();
        }
        MyDataSet mds;
        EmpAdapter empAdapter;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mds = new MyDataSet();
            DeptAdapter deptAdapter = new DeptAdapter();
            deptAdapter.Fill(mds.Departments);

            empAdapter = new EmpAdapter();
            empAdapter.Fill(mds.Employees);
            dgSet.ItemsSource = mds.Employees.DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            empAdapter.Update(mds.Employees);

        }
    }
}
