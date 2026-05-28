public class CustomSet(params int[] values)
{
    private readonly HashSet<int> values = [.. values];

    public CustomSet Add(int value)
    {
        values.Add(value);
        return this;
    }

    public bool Empty() => values.Count == 0;

    public bool Contains(int value) => values.Contains(value);

    public bool Subset(CustomSet right) => values.All(right.Contains);

    public bool Disjoint(CustomSet right) => !values.Any(right.Contains);

    public CustomSet Intersection(CustomSet right) => new([.. values.Intersect(right.values)]);

    public CustomSet Difference(CustomSet right) => new([.. values.Where(v => !right.Contains(v))]);

    public CustomSet Union(CustomSet right) => new([.. values.Union(right.values)]);

    public override bool Equals(object? obj) => obj is CustomSet other && Subset(other) && other.Subset(this);

    public override int GetHashCode() => HashCode.Combine(values);
}