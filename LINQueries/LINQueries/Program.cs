using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQueries
{
    class Employee
    {
        public int EmpNo { set; get; }
        public string Name { set; get; }
        public int DeptNo { set; get; }
        public decimal Basic { set; get; }
        public override string ToString()
        {
            return EmpNo + " " + Name + " " + DeptNo + " "+Basic;
        }
    }

    class Department
    {
        public int DeptNo { set; get; }
        public string Name { set; get; }

        public override string ToString()
        {
            return DeptNo + " " + Name;
        }
    }
   
    class Program
    {
        static List<Employee> lstemp = new List<Employee>();
        static List<Department> lstdept = new List<Department>();
        static void PopulateInfo()
        {
            lstemp.Add(new Employee { EmpNo = 101, Name = "Raj", DeptNo = 1, Basic = 85222 });
            lstemp.Add(new Employee { EmpNo = 102, Name = "jamvant", DeptNo = 2, Basic = 75222 });
            lstemp.Add(new Employee { EmpNo = 103, Name = "Sanju", DeptNo = 3, Basic = 45222 });
            lstemp.Add(new Employee { EmpNo = 104, Name = "Waggadu", DeptNo = 4, Basic = 25222 });
            lstemp.Add(new Employee { EmpNo = 105, Name = "Tamish", DeptNo = 2, Basic = 95222 });

            lstdept.Add(new Department { DeptNo = 1, Name = "IT" });
            lstdept.Add(new Department { DeptNo = 2, Name = "Marketing & Sales" });
            lstdept.Add(new Department { DeptNo = 3, Name = "Testing" });
            lstdept.Add(new Department { DeptNo = 4, Name = "HelpDesk" });

        }
        static void Main(string[] args)
        {
            PopulateInfo();

            //class should implement IEnumerable interface

            #region LINQ select object
            var emps = from emp in lstemp select emp;
            //using lambda & extension method
            //var emps = lstemp.Select(e=>e);


            foreach (var item in emps)
            {
                    Console.WriteLine(item);
            }
            #endregion

            Console.WriteLine("#2");
            var empb1 = lstemp.Where(emp => emp.DeptNo > 2).Select(e=>e.Name);
            var empb2 = lstemp.Where(emp => emp.DeptNo > 2).Select((emp)=> new { emp.Name,emp.DeptNo});
            foreach (var item in empb2)
            {
                Console.WriteLine(item.Name+" "+item.DeptNo);
                //Console.WriteLine(item);
            }


            Console.WriteLine("#3");
            var empc = lstdept.OrderBy(dep => dep.Name);//.Select(emp=>emp);
            foreach (var item in empc)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("#4");
            var empd = lstemp.OrderByDescending(emp => emp.EmpNo);
            foreach (var item in empd)
            {
                Console.WriteLine(item);
            }




            Console.WriteLine("#");
            var empsa = lstemp.Join(lstdept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => new { emp.EmpNo });

            foreach (var item in empsa)
            {
                Console.WriteLine(item.EmpNo);
            }
            Console.ReadLine();
        }

    }
}
