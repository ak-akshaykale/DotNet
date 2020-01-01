using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstClass
{
    class Program
    {
        static void Main(string[] args)
        {

            Demo d = new Demo();
            
            
            System.Console.Write("hello .net"+d.add(2,2,8));


            Console.ReadLine();
        }
    }
    class Demo
    {
        public int add(int a,int b,int c=0)
        {
            return a+b+c;
        }
    }
}
