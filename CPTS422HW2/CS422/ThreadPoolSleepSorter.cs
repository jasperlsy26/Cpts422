//Siyang Li 11443579 CS422 hw2

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS422
{
    public class ThreadPoolSleepSorter : IDisposable
    {
        private TextWriter writer;
        private BlockingCollection<MyTask> tasksCollection;
        private ushort numberOfThreads;
        private List<Thread> track;

        public class MyTask
        {
            public int value;
            public int sleepTime;
            public MyTask(int newValue)
            {
                value = newValue;
                sleepTime = value * 1000;// milli second
            }
            public void GoToSleep()
            {
                Thread.Sleep(sleepTime);
                //newTW.WriteLine(value);
            }
        }
        //constructor
        public ThreadPoolSleepSorter(TextWriter output, ushort threadCount)
        {
            writer = output;
            tasksCollection = new BlockingCollection<MyTask>();
            track = new List<Thread>();

            if (threadCount == 0)
            {
                this.numberOfThreads = 64;
            }
            else
            {
                this.numberOfThreads = threadCount;
            }
            
            for(int i = 0; i < numberOfThreads; i++)
            {
                Thread t = new Thread(() => SortHelp(tasksCollection));

                track.Add(t);
                //tasksCollection.Add(new MyTask());
                t.Start();

                
            }
        }

        /// <summary>
        /// Make sure you use WriteLine and not Write for each number. So the 
        /// result should be a sorted version of the list with one number per line
        /// </summary>
        /// <param name="values"></param>
        public void Sort(byte[] values)
        {
            //assume that the number of threads passed to the constructor of your class is greater
            //than or equal to the size of any array you’ll be asked to sort.
            MyTask mt;
            for (int i = 0; i < values.Length; i++)
            {
                mt = new MyTask(values[i]);
                tasksCollection.Add(mt);
            }


        }

        public void SortHelp(BlockingCollection<MyTask> tasksCollection)
        {
            while(tasksCollection != null)
            {
                if (tasksCollection.Contains(null)) { break; }
                MyTask task = tasksCollection.Take();
                task.GoToSleep();
                writer.WriteLine(task.value);
            }
        }

        public void Dispose()
        {
            foreach(Thread t in track)
            {
                t.Abort();
            }
        }
    }
}
