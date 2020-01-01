using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MulThreading
{
    class Program
    {
        //calling method by anonymous method & BeginInvoke
        static void Main1(string[] args)
        {

            Func<int, int> add = (i) => i + i;
            add.BeginInvoke(10, delegate (IAsyncResult rs) {
                int result = add.EndInvoke(rs);
                Console.WriteLine(" :: " + result);
            }, add);
            Console.ReadLine();
        }

        class Para
        {
            public int i;
            public int j;
        }

        // objThread.Start();
        static void Main2()
        {

            //Func<Para, int> mulc = (t) => t.i = t.i + t.j;
            Thread mulThread = new Thread(new ThreadStart(delegate {
                Console.WriteLine("Thread is running with anonymous function");
            }));
            mulThread.Start();
            Console.ReadLine();
        }
        static void Main3()
        {

            Action action = delegate {
                Console.WriteLine("Hello!");
            };
            Action<int> ij =myThread1;
            ij(10);
            Thread actionThread = new Thread(new ThreadStart(action));
            actionThread.Start();
            Console.ReadLine();
        }

        static void Main()
        {
            //Thread thread = new Thread(new ThreadStart(my))
            //delegate 
            ThreadPool.QueueUserWorkItem(new WaitCallback(myThread3),5);

            ThreadPool.QueueUserWorkItem(new WaitCallback(dee), 6);
            // ThreadPool.
            int workerThreads;
            int completeCode;
            ThreadPool.GetMaxThreads(out workerThreads,out completeCode);
            Console.WriteLine(" "+workerThreads+" "+completeCode);
            Console.ReadLine();
        }
        static void myThread3(object a)
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("thead1 runnnung in thread pool" + a);
            }
            
            //return 00;
        }

        static void dee(object ii)
        {
            for (int i = 0; i < 100; i++)
            {

                Console.WriteLine("ok ok " + ii);
            }
        }


        static void myThread1(int a)
        {
            Console.WriteLine("thead1 runnnung in thread pool");
           // return 00;
        }
        static void myThread2()
        {
            Console.WriteLine("thread2 runnnung in thread pool");
        }
    }
}
