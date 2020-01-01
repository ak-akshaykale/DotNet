using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            string result=service.GetData(50);
            Console.Write("result:: "+result);
            Console.Read();
        }
    }
}
