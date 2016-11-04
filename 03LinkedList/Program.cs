using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmvcc
{
    public class LinkedListClient
    {
        private static void Main(string[] args)
        {
            LinkedList<string> l = new LinkedList<string>();
            l.Add("F");
            l.Add("E");
            l.Print();
            l.Reverse();
            l.Print();
            l.Reverse();
            l.Add("D");
            l.Add("C");
            l.Add("B");
            l.Add("A");
            l.Add("test");
            l.Delete("test");
            //l.Delete("notfound"); // throws InvalidOperation exception
            l.Print();
            l.Reverse();
            Console.WriteLine("Called reverse. Now Print:");
            l.Print();
            l.Add("1");
            l.Add("2");
            l.Add("3");
            l.Add("4");
            l.Add("5");
            Console.WriteLine("Added 1-5. Now Print:");
            l.Print();
            l.Reverse();
            Console.WriteLine("Called Reverse.  Now Print:");
            l.Print();
            Console.ReadLine();
        }
    }

    [DebuggerDisplay("{Value}")]
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node()
        {
            Next = null;
        }
    }

    public class LinkedList<T>
    {
	    public Node<T> Head;
        public int Count { get; set; }
	
	    public LinkedList()
	    {
	      Head = null;
	    }

	    public void Add(T input)
	    {	
		    Node<T> newFirst = new Node<T>();
            newFirst.Value = input;
            newFirst.Next = Head;
		    Head = newFirst;
            Count++;
	    }
	
	    public void Delete(T toBeDeleted)
	    {
		    if( Head.Value.Equals(toBeDeleted)){
		      Head = Head.Next;
              Count--;
		      return;
		    }
        
		    Node<T> i = Head;
            Node<T> j = Head.Next;
				  
		    while(j!=null && i!=null)
		    {
		      if(j.Value.Equals(toBeDeleted))
		      {
			    i.Next = j.Next;
                Count--;
			    return;
		      }
              i = j;
              j = j.Next;
		    }
		    throw new InvalidOperationException("No item was not found");
	    }

        public void Reverse()
        {
            // 0 or 1 nodes we don't need to reverse
            if (Head == null || Head.Next == null)
                return;

            // if more than 2 nodes, continue changing nodes to point backwards in the while loop
            Node<T> prev = Head;  // previous
            Node<T> advanceNode = Head.Next;  //2nd node
            Node<T> futureAdvanceNode, lastKnownHead=null;
            while (advanceNode != null)
            {
                futureAdvanceNode = advanceNode.Next;
                advanceNode.Next = prev;
                prev = advanceNode;
                lastKnownHead = advanceNode;
                advanceNode = futureAdvanceNode;
            }
            Head.Next = null;
            Head = lastKnownHead;
        }


	    public void Print()
	    {
		    Node<T> i = Head;
		    while (i != null)
		    {
		      Console.WriteLine(i.Value + " ");
		      i = i.Next;
		    }
	    }
    }
}
