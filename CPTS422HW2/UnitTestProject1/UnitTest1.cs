using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using CS422;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PCQueue q = new PCQueue();
            Random rand = new Random();


        }



        /*
        
            if (dummy.next != null)
            {
                if (Object.ReferenceEquals(end, dummy))
                {
                    return false;
                }
                else if (Object.ReferenceEquals(front, dummy))
                {
                    front = front.next;
                    dummy.next = front.next;
                    return false;
                }
                else if (Object.ReferenceEquals(front, dummy.next))
                {
                    out_value = front.value;
                    dummy.next = front.next;
                    front = dummy;
                    return true;
                }
                else
                {
                    out_value = front.value;
                    front = front.next;
                    return true;
                }
            }
            else
            {
                if (Object.ReferenceEquals(front, dummy))
                {
                    return false;
                }
                else if (front.next != null)
                {
                    out_value = front.value;
                    front = front.next;
                    return true;
                }
                else if (front != null)
                {
                    out_value = front.value;
                    front = dummy;
                    return true;
                }
                else
                {
                    front = dummy;
                    return false;
                }
            }
        */
    }
}
