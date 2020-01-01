using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexersDemo
{
    class Students
    {
        object[] arr = new object[115];
        public object this[long substitute]
        {
            set
            {
                arr[substitute - 190840520001] = value;
            }
            get
            {
                return arr[substitute - 190840520001];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Students students = new Students();
            students[190840520001] = 81;
            students[190840520002] = 82;
            students[190840520003] = 83;
            students[190840520004] = "Fifty";
            students[190840520005] = 85;
            students[190840520006] = "Hundred";
            students[190840520007] = 83;
            students[190840520008] = 82;
            students[190840520009] = 81;
            students[190840520010] = 86;
            Console.WriteLine("Student:: "+students[190840520004]);
            Console.ReadLine();
        }
    }
}
