using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondClass
{
    class Program
    {
        static void MainCon(string[] args)
        {
            //No paramater 
            TestConstructor test = new TestConstructor();
            
            //paramatarized
            TestConstructor test2 = new TestConstructor(1651);

            test = null;
            test2 = null;
           // GC.Collect();
            Console.Read();
        }

        static void MainStat()
        {

            TestStatic ts = new TestStatic();
           // TestStatic.Static_para = 4500;
            Console.Write(TestStatic.Static_para);
            Console.Read();
        }

        static void MainSClass()
        {
            TestStaicClass.display();
           // Console.Write(tp);
            Console.Read();
        }

        static void Main()
        {
            TestProperties tp = new TestProperties();
            tp.A = 45;
            tp.B = 80;
            tp.c = 12;
            Console.WriteLine("Property A:"+tp.A);
            Console.WriteLine("Property B:"+tp.B);
            Console.WriteLine("Property C:" + tp.c);

            Console.Read();
        }
    }

    #region Constructor
    class TestConstructor
    {
        public TestConstructor()
        {
            Console.WriteLine("Hello constructor");
        }

        public TestConstructor(int x)
        {
            Console.Write("Hello constructor with para :: " + x);
        }

        ~TestConstructor()
        {
            Console.WriteLine("Destructor called");
            Console.Read();
        }
    }
    #endregion 
    class TestStatic
    {
        static TestStatic()
        {
            static_para = 0;
            Console.WriteLine("Static Constructor called");
        }

        public TestStatic()
        {
            Console.WriteLine("No paramatarized constructor called");
        }
        private static int static_para;
        public static int Static_para
        {
            set
            {
                static_para = value;
            }
            get
            {
                return static_para;
            }
        }
    }

    #region staticclass
    static class TestStaicClass
    {
        static int all=79846;
        public static void display()
        {
            Console.WriteLine(all);
        }
    }
    #endregion

    class TestProperties
    {
        private int a;
        private int b;
        public int c { set; get; }
        public int A
        {
            set
            {
                a = value;
            }
            get
            {
                return a;
            }
        }

        public int B
        {
            set { b = value; }
            get { return b; }
        }
    }

}
