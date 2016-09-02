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

            NumberedTextWriter ntw = new NumberedTextWriter(Console.Out);

            ntw.WriteLine("Hello World!");
            ntw.WriteLine("Hi!");

            Console.ReadKey();
            
        }
    }
}
