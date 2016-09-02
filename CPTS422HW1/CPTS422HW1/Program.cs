using CS422;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS422HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program p = new Program();

            //test NumberedTextWriter
            NumberedTextWriter ntw = new NumberedTextWriter(Console.Out);

            ntw.WriteLine("Hello World!");
            ntw.WriteLine("Hi!");

            //test IndexedNumsStream,
            IndexedNumsStream ins = new IndexedNumsStream(0);

            byte[] buffer = new byte[512];

            ins.SetLength(512);

            ins.Read(buffer, 0, 512);

            foreach (byte num in buffer)
            {
                Console.WriteLine(num);
            }

        }
    }
}
