using System.Collections;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public required T Value { get; set; }

        public Node? Next { get; set; }
    }

    public SimpleLinkedList(params IEnumerable<T> values)
    {
        foreach (var value in values)
        {
            Push(value);
        }
    }

    private Node? root;
    private int count = 0;

    public int Count => count;

    public void Push(T value)
    {
        root = new Node
        {
            Value = value,
            Next = root,
        };
        count++;
    }

    public T Pop()
    {
        if (root is null) throw new InvalidOperationException();

        var value = root.Value;
        root = root?.Next;
        count--;
        return value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = root;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }    
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}