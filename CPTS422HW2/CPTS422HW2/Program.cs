using CS422;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CPTS422HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            test testing = new test();

            Thread t1 = new Thread(new ThreadStart(testing.enqueue));
            Thread t2 = new Thread(new ThreadStart(testing.dequeue));
            t1.Start();
            t2.Start();
            */

            ThreadPoolSleepSorter sort = new ThreadPoolSleepSorter(Console.Out, 10);

            byte[] arr = new byte[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            sort.Sort(arr);



            Console.ReadKey();

            sort.Dispose();

            //byte[] arr1 = new byte[] { 8, 8, 7, 6, 5, 4, 3, 2, 1 };
            //sort.Sort(arr1);


            /*
            int out1=0, out2=0, out3 = 0;

            PCQueue q = new PCQueue();
            q.Enqueue(2);
            q.Enqueue(1);
            q.Enqueue(3);
            q.Enqueue(7);
            q.Enqueue(12);
            q.Enqueue(9);

            q.Dequeue(ref out1);
            q.Dequeue(ref out2);
            q.Dequeue(ref out3);

            
            Console.ReadKey();
            */
        }

    }

    public class test
    {
        PCQueue queue1;

        public test()
        {
            queue1 = new PCQueue();
        }

        public void enqueue()
        {
            for (long i = 1; i < 100000000; i++)
            {
                queue1.Enqueue((int)(i % 100));
                //Console.WriteLine(i);

            }
            Console.WriteLine("Done enqueue");


        }

        public void dequeue()
        {
            int j = 0;
            for (long i = 1; i < 100000000; i++)
            {
                while (queue1.Dequeue(ref j) == false)
                {
                }
                if (j == (int)(i % 100))
                {

                }
                else
                {
                    Console.WriteLine("False");
                }
            }
            Console.WriteLine("Done dequeue");
            Console.ReadKey();
        }
    }
}

