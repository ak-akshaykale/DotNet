using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferencesndValue
{
    //all classes and their variants and reference type
    //all struct and their variants are value type

    class Program
    {
        //reference (Ref keyword)need already initialize reference
        #region swaping reference
        static void Main2()
        {
            Class1 cls = new Class1();
            //pass by value fail to swap
            Class1.swap(cls.a,cls.b);
            cls.display();

            //using ref keyword pass by reference
            Class1.swapRef(ref cls.a,ref cls.b);
            cls.display();
            Console.Read();
        }
        #endregion

        //it initialize (out keyword) the variables
        #region initialization using out keyword
        public static void initialize(out int x,out int y)
        {
            x = 24;
            y = 45;
        }

   
        static void Main()
        {
            int x;
            int y;
           initialize(out x, out y);
           Console.WriteLine("x: "+x+"\ny: "+y);
            Console.Read();
        }
        #endregion
    }

    class CTD
    {
        //  C#              CTD     size
        public bool b; //   Boolean 1byte
        public short s; //  Int16   2bytes
        public ushort us;// Int16   2bytes 
        public int i;   //  Int32    4bytes
        public uint ui;  //  Int32   4bytes
        public float f; //  Int32      4bytes
        public long l;  //  Int64      8bytes
        public ulong ul;  //  Int64    8bytes
        public double d; // Int64      8bytes
        public decimal dc;// Int128    16bytes

    }

    #region reference
    class Class1
    {
        public int a = 10;
        public int b = 20;

       
        public static void swap(int a,int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void swapRef(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public void display()
        {
            Console.WriteLine("a: "+a+"\nb: "+b);
        }
    }
    #endregion
    class Class2
    {

    }
}
