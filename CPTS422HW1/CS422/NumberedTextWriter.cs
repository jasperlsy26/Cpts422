using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS422
{
    public class NumberedTextWriter : TextWriter
    {
        private int currentLineNumber;
        private TextWriter tw;

        
        #region public get/set for private members
        public int CurrentLineNumber
        {
            get { return currentLineNumber; }
            set { currentLineNumber = value; }
        }
        public TextWriter TW
        {
            get { return tw; }
            set { TW = value; }
        }
        #endregion
        


        public NumberedTextWriter(TextWriter wrapThis)
        {
            tw = wrapThis;
            currentLineNumber = 1;
        }

        public NumberedTextWriter(TextWriter wrapThis, int startingLineNumber)
        {
            tw = wrapThis;
            currentLineNumber = startingLineNumber;
        }

        public override Encoding Encoding
        {
            get
            {
                return tw.Encoding;
            }
        }

        public override void WriteLine(string value)
        {
            tw.WriteLine(currentLineNumber.ToString() + ":" + " " + value);
            currentLineNumber++;
        }



    }
}
