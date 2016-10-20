using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlist
{
    public class LinkedList<T>
    {
	    public Node<T> first;
	    int count = 0;
	
	    public LinkedList<T>()
	    {
	      first = null;
	    }

	    public void Add(T input)
	    {	
		    Node newFirst = new Node<T>(input);
		    newFirst.Next = first;
		    first = newFirst;
	    }
	
	    public void Delete(T toBeDeleted)
	    {
		    if( first.Value == toBeDeleted){
		      first = first.Next;
		      return;
		    }
        
		    Node i,j;
		    i = first;
		    j = first.Next;
				  
		    while(j!=null && i!=null)
		    {
		      if(j.Value == toBeDeleted)
		      {
			    i.Next = j.Next;
			    return;
		      }
		    }
		    throw InvalidOperationException("No item was not found");
	    }
	
	    public void Print()
	    {
		    Node i = first;
		    while (i != null)
		    {
		      Console.WriteLine(i.Value + " ");
		      i = i.Next;
		    }
	    }
    }
}

*/