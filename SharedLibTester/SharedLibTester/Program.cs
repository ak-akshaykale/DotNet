using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibTester
{
    class Program
    {
        static void Main(string[] args)
        {
            SharedAssembly.SharedLib.sayHello();
            Console.ReadLine();
        }
    }
}
