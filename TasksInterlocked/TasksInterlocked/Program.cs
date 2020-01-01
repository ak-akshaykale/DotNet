using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace TasksInterlocked
{
    class Program
    {

        static void Main(string[] args)
        {
            // var a = new AppDomainSetup;

            //Anonymous class
            var a = new {NAME="adsd",OO="adsad" };

            //same class in generated in back
            var b = new {NAME="adsd",OO="adsad" };

            ///de
            var c = new { NAME = "adsd", OO = "adsad",UU=465 };


            int i = 10;
            double d = 0;
            double d2 = 0;
            //i = i + 12;
            int isa =Interlocked.Add(ref i, 12);
            double ss= Interlocked.CompareExchange(ref d2, d2,11.11);
            Console.WriteLine(isa);
            Console.WriteLine(ss);


            //#1
            Task t = new Task(hello);
            t.Start();
            //#2
            Action ae = hello;
            Task.Run(ae);

            //#3
            Task.Factory.StartNew(ae);

            Action displayAction = display;
            Task task1 = new Task(displayAction);
            task1.Start();
            Console.ReadLine();
        }
        static void hello()
        {
            Thread.Sleep(8000);
            Console.WriteLine("Welcome to JUHU");

        }

        static void display()
        {
            int i = 0;
            while (i < 4654646)
            {
                Thread.Sleep(3000);
                Console.WriteLine("DIS :: ");
            }
        }
            //return data;
       
    }
}
