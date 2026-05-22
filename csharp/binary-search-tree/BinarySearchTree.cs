using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value)
    {
        Value = value;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        using var e = values.GetEnumerator();

        if (!e.MoveNext()) throw new ArgumentException("Values cannot be empty");

        Value = e.Current;

        while (e.MoveNext())
        {
            Add(e.Current);
        }
    }

    public int Value { get; init; }

    public BinarySearchTree? Left { get; private set; }

    public BinarySearchTree? Right { get; private set; }

    public BinarySearchTree Add(int value)
    {
        if (value <= Value)
        {
            if (Left is null)
            {
                Left = new BinarySearchTree(value);
            }
            else
            {
                Left.Add(value);
            }
        }
        else
        {
            if (Right is null)
            {
                Right = new BinarySearchTree(value);
            }
            else
            {
                Right.Add(value);
            }
        }

        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (Left != null)
        {
            foreach (var value in Left) yield return value;
        }

        yield return Value;

        if (Right != null)
        {
            foreach (var value in Right) yield return value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}