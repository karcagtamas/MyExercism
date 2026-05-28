using System.Collections;

public class Node(string name) : IEnumerable<Attr>
{
    public string Name { get; } = name;
    private readonly List<Attr> attrs = [];

    public void Add(Attr attr) => attrs.Add(attr);

    public void Add(string key, string value) => attrs.Add(new Attr(key, value));

    public override bool Equals(object? obj) =>
        obj is Node other
        && Name == other.Name
        && attrs.SequenceEqual(other.attrs);

    public override int GetHashCode() => HashCode.Combine(Name);

    public IEnumerator<Attr> GetEnumerator() => attrs.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Edge(string from, string to) : IEnumerable<Attr>
{
    public string From { get; } = from;
    public string To { get; } = to;
    private readonly List<Attr> attrs = [];

    public void Add(Attr attr) => attrs.Add(attr);

    public void Add(string key, string value) => attrs.Add(new Attr(key, value));

    public override bool Equals(object? obj) =>
        obj is Edge other
        && From == other.From
        && To == other.To && attrs.SequenceEqual(other.attrs);

    public override int GetHashCode() => HashCode.Combine(From, To);

    public IEnumerator<Attr> GetEnumerator() => attrs.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Attr(string key, string value)
{
    public string Key { get; } = key;
    public string Value { get; } = value;

    public override bool Equals(object? obj) => obj is Attr other && Key == other.Key && Value == other.Value;

    public override int GetHashCode() => HashCode.Combine(Key, Value);
}

public class Graph : IEnumerable<object>
{
    private readonly List<object> items = [];
    public List<Node> Nodes { get; } = [];
    public List<Edge> Edges { get; } = [];
    public List<Attr> Attrs { get; } = [];

    public void Add(Node node)
    {
        Nodes.Add(node);
        items.Add(node);
    }

    public void Add(Edge edge)
    {
        Edges.Add(edge);
        items.Add(edge);
    }

    public void Add(Attr attr)
    {
        Attrs.Add(attr);
        items.Add(attr);
    }

    public void Add(string key, string value)
    {
        var attr = new Attr(key, value);
        Attrs.Add(attr);
        items.Add(attr);
    }

    public override bool Equals(object? obj) =>
        obj is Graph other
        && Nodes.SequenceEqual(other.Nodes)
        && Edges.SequenceEqual(other.Edges)
        && Attrs.SequenceEqual(other.Attrs);
    public override int GetHashCode() => HashCode.Combine(Nodes.Count, Edges.Count, Attrs.Count);

    public IEnumerator<object> GetEnumerator() => items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}