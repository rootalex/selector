using System;

public class Node<T> where T : IComparable
{
	public Node(T theKey)
	{
        key = theKey;
        
	}
   public Node<T> left = null;
    public Node<T> right = null;
    public T key;
}
