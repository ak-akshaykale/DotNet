using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Client
{
    class Program
    {
        //#Without Async
        static void Main1(string[] args)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            Console.WriteLine("Begin");
            string retresult=service.GetData(20);
            Console.WriteLine("Result from WCF:: " + retresult);
            Console.WriteLine("end");
            Console.WriteLine("Result ::");
            Console.Read();
        }

        //Async calling in multithreading
        static void Main()
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            service.GetDataCompleted += Service_GetDataCompleted;
            Console.WriteLine("Begin");
            service.GetDataAsync(50);
            Console.WriteLine("end");
            service.SayHello();
            Console.Read();
        }

        private static void Service_GetDataCompleted(object sender, ServiceReference1.GetDataCompletedEventArgs e)
        {
            string data = e.Result;
            Console.WriteLine(data);
        }
    }
}
