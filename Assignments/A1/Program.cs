using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1
{
    class Program
    {
        static void Main2()
        {

            #region A1
            Employee e1 = new Employee();
            e1.Emp_no = 1;
            e1.Name = "AKSHAY";
            e1.Dept_no = 2;
            e1.Basic = 50000;

            Console.WriteLine("--EMPLOYEE");
            Console.WriteLine("EmpNO: " + e1.Emp_no + "\nName: " + e1.Name + "\nDept_no: " + e1.Dept_no + "\nBasic Salary: " + e1.Basic);
            Console.WriteLine("-----------------------");

            Employee e2 = new Employee();
            e2.Emp_no = -2;
            e2.Name = "";
            e2.Dept_no = -3;
            e2.Basic = 90000000;
            Console.WriteLine("--EMPLOYEE");
            Console.WriteLine("EmpNO: " + e2.Emp_no + "\nName: " + e2.Name + "\nDept_no: " + e2.Dept_no + "\nBasic Salary: " + e2.Basic);
            Console.WriteLine("-----------------------");

            //constructor overload
            Employee e3 = new Employee(-1, "");
            Console.WriteLine("EmpNO: " + e3.Emp_no + "\nName: " + e3.Name + "\nDept_no: " + e3.Dept_no + "\nBasic Salary: " + e3.Basic);
            Console.WriteLine("-----------------------");

            Employee e4 = new Employee(2, "imran", 4565);
            Console.WriteLine("EmpNO: " + e4.Emp_no + "\nName: " + e4.Name + "\nDept_no: " + e4.Dept_no + "\nBasic Salary: " + e4.Basic);
            Console.WriteLine("-----------------------");

            //named para
            Employee e5 = new Employee(xempno: 4, xbase: 6);
            #endregion
            Console.Read();
        }
        static void Main()
        {
            Employee2 emp1 = new Employee2("deepak",12,5);
            Console.WriteLine("empNo: "+emp1.Emp_no+"\nEName: "+emp1.Name+"\nBasic: "+emp1.Basic+"\nDeptNo: "+emp1.Dept_no);
            Console.WriteLine("----------");
            Employee2 emp2 = new Employee2("sf", 12233, 2);
            Console.WriteLine("empNo: " + emp2.Emp_no + "\nEName: " + emp2.Name + "\nBasic: " + emp2.Basic + "\nDeptNo: " + emp2.Dept_no);
            Console.WriteLine("----------");

            Employee2 emp3 = new Employee2("sfsgsf", 12132342, 3);
            Console.WriteLine("empNo: " + emp3.Emp_no + "\nEName: " + emp3.Name + "\nBasic: " + emp3.Basic + "\nDeptNo: " + emp3.Dept_no);
            Console.WriteLine("----------");

            Employee2 emp4 = new Employee2("gdfgdg", 324412, 4);
            Console.WriteLine("empNo: " + emp4.Emp_no + "\nEName: " + emp4.Name + "\nBasic: " + emp4.Basic + "\nDeptNo: " + emp4.Dept_no);
            Console.WriteLine("----------");

            Console.WriteLine("Net salary: "+emp1.CalculateNetsal());
            Console.Read();
        }
    }

    #region A1
    class Employee
    {
        private int emp_no;
        private string name;
        private decimal basic;
        private short dept_no;

        public Employee()
        {

        }
        public Employee(int xempno,string xname="",decimal xbase=0,short xdept=0)
        {
            Emp_no = xempno;
            Name = xname;
            Basic = xbase;
            Dept_no = xdept;
        }

        public int Emp_no
        {
            set
            {
                if(value>0)
                    emp_no = value;
                else
                    Console.WriteLine("Invalid employee number");
            }
            get
            {
                return emp_no;
            }
        }

        public string Name
        {
            set
            {
                if (!value.Equals(""))
                    name = value;
                else
                    Console.WriteLine("Invalid Name");
            }
            get
            {
                return name;
            }
        }

        public decimal Basic
        {
            set
            {
                if (value > 0 && value<80000 )
                    basic = value;
                else
                    Console.WriteLine("Invalid Basic Salary");
            }
            get {
                return basic;
            }
        }

        public short Dept_no
        {
            set
            {
                if (value > 0)
                    dept_no = value;
                else
                    Console.WriteLine("Invalid Department Number");
            }
            get
            {
                return dept_no;
            }
        }

        public float CalculateNetsal()
        {
            return 11.5f * (int)basic * 65546;
        }
    }
    #endregion


    #region B1
    class Employee2
    {
        private static int auto_empno=1;
        private int emp_no;
        private string name;
        private decimal basic;
        private short dept_no;
        
        public Employee2(string xname = "", decimal xbase = 0, short xdept = 0)
        {
            emp_no = auto_empno;
            Name = xname;
            Basic = xbase;
            Dept_no = xdept;
            auto_empno++;
        }

        public int Emp_no
        {
            get
            {
                return emp_no;
            }
        }

        public string Name
        {
            set
            {
                if (!value.Equals(""))
                    name = value;
                else
                    Console.WriteLine("Invalid Name");
            }
            get
            {
                return name;
            }
        }

        public decimal Basic
        {
            set
            {
                if (value > 0 && value < 80000)
                    basic = value;
                else
                    Console.WriteLine("Invalid Basic Salary");
            }
            get
            {
                return basic;
            }
        }

        public short Dept_no
        {
            set
            {
                if (value > 0)
                    dept_no = value;
                else
                    Console.WriteLine("Invalid Department Number");
            }
            get
            {
                return dept_no;
            }
        }
        public float CalculateNetsal()
        {
            return 11.11f * (float)basic * 100;
        }
    }
    #endregion
}
