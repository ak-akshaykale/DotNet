using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdClass
{
    struct Data
    {
        int a;
        int b;

        //cannot create explicit parameterless constructor
        /*public Data()
        {

        }*/

        public Data(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public void displayAB()
        {
            Console.WriteLine("A: "+a+"\nB: "+b);
        }
    }



    class Program
    {
        #region Struct TEST
        static void Main1(string[] args)
        {
            Data d = new Data(30,90);
            d.displayAB();
            Console.ReadLine();
        }
        #endregion

        #region ? NullType -> Nullable(class) & Convert class
        static void Main2()
        {
            string aabc = null;
            int x = 10; //null cannot assign to value type 
            int y = 20; //in database it is require.
            if (x!=null)
                x = 1123;

            //NullType

            int? nx; //internally uses Generic type .
                    // Nullable<int> nx = new Nullable<>();
            nx = null;
            int? ny = 200;

            //assign value to nullType to normal type (convert or typecast)
            y = (int)ny;
            y = int.Parse(""+ny);
            y = Convert.ToInt32(ny);


            //method 1
            if (nx != null)
                ny = nx;

            //method 2
            if (nx.HasValue)
            {
                ny = nx;
            }

            //method 3
            ny = nx ?? ny;

            Console.WriteLine(ny);
            Console.ReadLine();
        }
        #endregion

        static void Main()
        {
            
            #region simple array and diplay
            int[] arr = new int[5];
            arr[0] = 10;
            arr[1] = 20;
            arr[2] = 30;
            arr[3] = 40;
            arr[4] = 50;

            //display by for loop can modify 
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}
            //display by foreach can not modify
            foreach (int item in arr)
            {
                //item = 120; not allowed
                Console.WriteLine(item);
            }
            #endregion

            #region Array Methods
            //Array class methods
            int[]arr2 = new int[] { 8,5,4,7,6,3};
            Array.Copy(arr2, arr, 3);

            Array.Sort(arr2);

            arr2.SetValue(8, 3);
            //for Binary search array should be sorted
            int result = Array.BinarySearch(arr2, 5);
            Console.WriteLine(result); //if not found return -1 , if found return position

            int indx = Array.LastIndexOf(arr2, 5); //position
            Console.WriteLine(indx);

            foreach (var item in arr2)
            {
                Console.WriteLine(item);
            }
            #endregion
            
            int[,] arr2D = new int[3,2];

            //GetLength(0) - first dimension that is 3
            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                //GetLength(1) - 2nd that is 2
                for (int j = 0; j < arr2D.GetLength(1); j++)
                {
                    Console.WriteLine("Enter the value {0}:{1} ::", i, j);
                    arr2D[i,j]=int.Parse(Console.ReadLine());
                }

            }

            foreach (var item in arr2D)
            {
                Console.WriteLine(item);
            }

            //GetLowerBound-GetUpperBound
            Console.WriteLine("LowerBound: "+arr2D.GetLowerBound(0));
            Console.WriteLine("UpperBound: "+arr2D.GetUpperBound(0));
            Console.ReadLine();

        }
    }
}
