using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    class Program
    {
        //1
        static void Main1(string[] args)
        {
            int size = 4;
            string[] name = new string[size];
            int[] marks = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("enter name: ");
                name[i] =Console.ReadLine();
                Console.WriteLine("enter mark: ");
                marks[i]=int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("-------------");
                Console.WriteLine("Name: "+name[i]);
                Console.WriteLine("Mark: "+marks[i]);
            }
            Console.WriteLine("Maximum Marks: "+marks.Max());
            Console.WriteLine("Minimum Marks: "+marks.Min());
            Console.ReadLine(); 
        }
        static void Main()
        {
            int[][] cdac = new int[2][];

            cdac[0]= new int[1];
            cdac[1] = new int[2];
            cdac[2] = new int[3];

            //cdac[0][1] = 213;

            cdac[1][0] = 3123;
            cdac[1][1] = 133;

            cdac[2][0] = 44;
            cdac[2][1] = 55;
            cdac[2][2] = 54;

            foreach (int[] item in cdac)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

    }



}
