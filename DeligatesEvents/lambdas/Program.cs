using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace lambdas
{
    class Program
    {
        class Employee
        {
            public decimal Basic { set; get; }
            
            //publi
        }
        static void Main()
        {
            //Lambda function 1
            Func<int, int> getDouble = i => i*2;
            /* getDouble.BeginInvoke(80, delegate (IAsyncResult rs) {
                 int result = getDouble.EndInvoke(rs);
                 Console.WriteLine(result);
             },getDouble);*/

            //Interlocked.
            
            Predicate<Employee> preEmp = (emp) => emp.Basic > 10000;

            Console.WriteLine("Employee:: "+    preEmp(new Employee { Basic=50000 })); 
            //Console.WriteLine(asd);
            Func<int, bool> isEven = i => i%2==0;
            isEven.BeginInvoke(21, delegate(IAsyncResult ar) {
                bool result = isEven.EndInvoke(ar);
                Console.WriteLine("isEven {0}",result);
            }, null);

            //default only boolean as return datatype
            Predicate<int> isGreater = (i) => i>80;
            
            //#1
            /*isGreater.BeginInvoke(100,delegate(IAsyncResult rs){
                bool br=isGreater.EndInvoke(rs);
                Console.WriteLine(br);
            },null);
            */
            //#2
            Console.WriteLine(isGreater(110));

            //always returns void
            Action<int> a = helloRag;
            a(0);

            //only in para , out is void always
            Action<int, object> objAction = helloObject;
            objAction(12, new object());


            //in para , out para
            Func<int,int> objFunc = sayFunc;
            objFunc(11);

            Console.ReadLine();
        }
        static void helloRag(int a)
        {
            Console.WriteLine("Hello raga is of "+a);
        }
        static void helloObject(int a, object b)
        {
            Console.WriteLine(b+" of value is "+a);
        }

        static int sayFunc(int x)
        {
            Console.WriteLine("say hello by func delegate which have return type "+x);
            return 00;
        }
    }
}
