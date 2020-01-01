using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    interface IDBFunction
    {
        void display();
    }

   abstract class Employee
    {
        static int autoEID=1;
        private int empNo;
        private string name;
        protected decimal basic;
        private short deptNo;

       public Employee(string name, decimal basic, short deptno)
        {
            empNo = autoEID;
            Name = name;
            Basic = basic;
            DeptNo = deptno;
            autoEID++;
        }
        public int EmpNo
        {
            get{ return empNo; }
        }

        public string Name
        {
            set
            {
                if (!value.Equals(""))
                    name = value;
            }
            get
            {
                return name;
            }
        }

        abstract public decimal Basic {set;get; }

        public short DeptNo
        {
            set
            {
                if (value > 0)
                    deptNo = value;
            }
            get
            {
                return deptNo;
            }
        }

        abstract public decimal CalcNetSalary();
    }

    abstract class Manager : Employee
    {
        private int projectID;
        public Manager(string name,decimal basic,short deptno,int projectID) : base(name,basic,deptno)
        {
            ProjectID = projectID;
        }

        public int ProjectID
        {
            set
            {
                if (value > 0)
                    projectID = value;
            }
            get
            {
                return projectID;
            }
        }
        public abstract override decimal Basic { get; set; }
        public abstract override decimal CalcNetSalary();
        
    }

    class Clerk :Employee,IDBFunction
    {
        private int overTimeHours;

        public Clerk(string name,decimal basic,short deptno,int overTimeHours): base(name, basic, deptno)
        {
            OverTimeHours = overTimeHours;
        }
        public int OverTimeHours
        {
            set
            {
                if (value > 0)
                    overTimeHours = value;
            }
            get
            {
                return overTimeHours;
            }
        }

        public override decimal Basic
        {
            get
            {
                return basic;
            }
            set
            {
                if (value > 5000 && value < 30000)
                    basic = value;
            }
        }

        public sealed override decimal CalcNetSalary()
        {
            return Basic + 4654 - 600 - 300 - 787;
        }

        public void display()
        {
            //string name,decimal basic,short deptno,int overTimeHours
            Console.WriteLine("---EMPLOYEE(Clerk)---");
            Console.WriteLine("EmpNo: " + EmpNo);
            Console.WriteLine("Name: "+Name);
            Console.WriteLine("Basic Salary: "+Basic);
            Console.WriteLine("DeptNo: "+DeptNo);
            Console.WriteLine("OverTimeHours: "+OverTimeHours);
            Console.WriteLine("Net Salary: "+CalcNetSalary());

        }
    }

    class GeneralManager: Manager, IDBFunction
    {
        public string Perks;

        public GeneralManager(string name, decimal basic, short deptno, int projectID,string perks):base(name,basic,deptno,projectID)
        {
            Perks = perks;
        }
        public override decimal Basic
        {
            get
            {
                return basic;
            }
            set
            {
                if (value > 25000 && value < 80000)
                    basic = value;
            }
        }

        public override decimal CalcNetSalary()
        {
            return Basic + 8654 - 1200 - 600 - 1487;
        }

        public void display()
        {
            //string name, decimal basic, short deptno, int projectID,string perks
                Console.WriteLine("---EMPLOYEE(General Manager)---");
                Console.WriteLine("EmpNo: " + EmpNo);
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Basic Salary: " + Basic);
                Console.WriteLine("DeptNo: " + DeptNo);
                Console.WriteLine("ProjectID: " + ProjectID);
                Console.WriteLine("Perks: " + Perks);
                Console.WriteLine("Net Salary: " + CalcNetSalary());
                Console.WriteLine("-----------");
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GeneralManager gmanager = new GeneralManager("SAGAR",40000,2,104,"Kashmir Trip 4 Days");
            Clerk clerk = new Clerk("RAJU",21000,13,3);
            GeneralManager gmanager1 = new GeneralManager("Mayuresh", 50000, 4, 107, "Nepal visit");
            Clerk clerk1 = new Clerk("RAJU", 21000, 13, 3);
            GeneralManager gmanager2 = new GeneralManager("Deepak", 40000, 2, 104, "US Tour 3 month");
            Clerk clerk2 = new Clerk("RAJU", 21000, 13, 3);

            gmanager.display();
            gmanager1.display();
            gmanager2.display();
            clerk.display();
            clerk1.display();
            clerk2.display();
            Console.ReadLine();
        }
    }
}
