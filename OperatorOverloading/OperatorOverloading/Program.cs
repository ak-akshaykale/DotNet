using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    class Car
    {
        public string Name { set; get; }
        public string Color { set; get; }
        public int Maxcapacity { set; get; }

        public static Car operator +(Car c1, Car c2)
        {
            Car c = new Car();
            c.Name = c1.Name + " & " + c2.Name;
            c.Color = c1.Color + " & " + c2.Color;
            c.Maxcapacity = c1.Maxcapacity + c2.Maxcapacity;
            return c;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car();
            c1.Name = "Oddi";
            c1.Color = "Black";
            c1.Maxcapacity = 6;

            Car c2 = new Car();
            c2.Name = "BMW";
            c2.Color = "Blue";
            c2.Maxcapacity = 4;


            Car c3 = new Car();
            c3 = c1 + c2;

            Console.WriteLine(c3.Name+" \n"+c3.Maxcapacity);
            Console.ReadLine();
        }
    }
}
