using System;

namespace CS422
{
    public class PCQueue
    {
        private Node front;
        private Node end;
        private Node dummy;

        public PCQueue()
        {
            front = new Node();
            end = new Node();
            dummy = new Node();
            front = end = dummy;
            
        }

        public void Enqueue(int dataValue)
        {
            end.next = new Node(dataValue);
            end = end.next;
        }

        public bool Dequeue(ref int out_value)
        {
            // empty queue
            if(object.ReferenceEquals(dummy, end)) { return false; }

            //only 1 note in queue. end -> note, front, dummy -> null
            if (object.ReferenceEquals(dummy, front)) { front = front.next; }

            
            out_value = front.value;
            //case: only 1 note----right now end, front -> note, dummy -> null
            if (object.ReferenceEquals(front, end))
            {
                front = end = dummy;
            }
            //case: mutiple notes in queue
            else
            {
                front = front.next;
            }

            return true;
        }

        public class Node
        {
            internal Node next;
            internal int value;

            public Node()
            {
                next = null;
            }
            public Node(int newData)
            {
                next = null;
                value = newData;
            }
            public Node(Node nextNode, int newData)
            {
                next = nextNode;
                value = newData;
            }

        }
    }
}
