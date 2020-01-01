using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClasses
{
    partial class Myclass
    {
        int a;
        int b;

        //partial method return type is void only
        partial void dislpay(int a);

        public int change()
        {
            dislpay(10);
            return 25;
        }

    }

    partial class Myclass
    {
        partial void dislpay(int a)
        {
            this.a = a;
            b = a * a;
            Console.WriteLine("a::{0} b:{1}",a,b);
        }
    }
    class Program
    {
      //  class StringMethodAdder
        //{
            //shloud be static with the parameter this class(that class that we want to extension metnod)
            static string StringWordReverser(this string ss)
            {
                return ss + (0 * 0 * 0) + ss;
            }
      //  }
        static void Main(string[] args)
        {
            Myclass m = new Myclass();
            Console.WriteLine(  m.change());

            //ExtensionMethod.StringMethodAdder str = new ExtensionMethod.StringMethodAdder();
            //str.
            string str = "asdds";
            //str.
            Console.ReadLine();

        }
    }
}