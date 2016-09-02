using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS422
{
    public class IndexedNumsStream : Stream
    {
        private long currentPosition;
        private long length;



        public IndexedNumsStream(long value)
        {
            currentPosition = 0;
            if (value < 0)
            {
                length = 0;
            }
            else
            {
                length = value;
            }
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override long Length
        {
            get
            {
                return length;
            }
        }

        public override long Position
        {
            get
            {
                return currentPosition;
            }

            set
            {
                if (value < 0) { currentPosition = 0; }
                else if (value > length) { currentPosition = length; }
                else { currentPosition = value; }
            }
        }

        public override void Flush()
        {
            //baseStream.Flush();
            throw new NotImplementedException();
        }

        /// <summary>
        /// something wrong with my Read
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            // fixed. i < count + offset
            for (long i = offset; (i < (count + offset)) && ((byte)currentPosition < length); i++)
            {

                buffer[i] = (byte)(currentPosition % 256);
                currentPosition++;
            }

            return count;
        }

        //set position
        public override long Seek(long offset, SeekOrigin origin)
        {
            long desiredPosition = currentPosition + offset;

            if(desiredPosition < 0)
            {
                currentPosition = 0;
            }else if(desiredPosition > length)
            {
                currentPosition = length;
            }
            else
            {
                currentPosition = desiredPosition;
            }

            return currentPosition;
        }

        /// <summary>
        /// maybe not ok
        /// </summary>
        /// <param name="value"></param>
        public override void SetLength(long value)
        {
            if (value < 0)
            {
                length = 0;
            }
            else
            {
                length = value;
            }
        }

        /// <summary>
        /// Read-only stream, no need for Write
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
