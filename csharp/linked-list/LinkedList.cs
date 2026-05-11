public class Deque<T>
{
    class Node<U>(T value, Node<T>? next = null, Node<T>? previous = null)
    {
        public T Value { get; } = value;
        public Node<T>? Next { get; set; } = next;
        public Node<T>? Previous { get; set; } = previous;
    }

    private Node<T>? head = null;
    private Node<T>? tail = null;

    public void Push(T value)
    {
        var node = new Node<T>(value, null, tail);

        if (tail == null)
        {
            head = node;
        }
        else
        {
            tail.Next = node;
        }

        tail = node;
    }

    public T Pop()
    {
        var node = tail!;

        tail = node.Previous;

        if (tail == null)
        {
            head = null;
        }
        else
        {
            tail.Next = null;
        }

        return node.Value;
    }

    public void Unshift(T value)
    {
        var node = new Node<T>(value, head);

        if (head == null)
        {
            tail = node;
        }
        else
        {
            head.Previous = node;
        }

        head = node;
    }

    public T Shift()
    {
        var node = head!;

        head = node.Next;

        if (head == null)
        {
            tail = null;
        }
        else
        {
            head.Previous = null;
        }

        return node.Value;
    }
}