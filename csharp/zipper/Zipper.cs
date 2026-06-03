public class BinTree(int value, BinTree? left, BinTree? right) : IEquatable<BinTree>
{
    public int Value { get; } = value;
    public BinTree? Left { get; } = left;
    public BinTree? Right { get; } = right;

    public bool Equals(BinTree? other) => other is not null && Value == other.Value && Equals(Left, other.Left) && Equals(Right, other.Right);

    public override bool Equals(object? obj) => Equals(obj as BinTree);

    public override int GetHashCode() => HashCode.Combine(Value, Left, Right);
}

public class Zipper(BinTree focus, List<Zipper.Crumb> crumbs)
{
    public sealed class Crumb(int value, BinTree? otherChild, bool cameFromLeft)
    {
        public int Value { get; set; } = value;
        public BinTree? OtherChild { get; set; } = otherChild;
        public bool CameFromLeft { get; set; } = cameFromLeft;
    }

    private readonly BinTree focus = focus;
    private readonly List<Crumb> crumbs = crumbs;

    public int Value() => focus.Value;

    public Zipper SetValue(int newValue) => new(new BinTree(newValue, focus.Left, focus.Right), [.. crumbs]);

    public Zipper SetLeft(BinTree? binTree) => new(new BinTree(focus.Value, binTree, focus.Right), [.. crumbs]);

    public Zipper SetRight(BinTree? binTree) => new(new BinTree(focus.Value, focus.Left, binTree), [.. crumbs]);

    public Zipper? Left()
    {
        if (focus.Left is null) return null;

        List<Crumb> newCrumbs = [.. crumbs, new Crumb(focus.Value, focus.Right, true)];

        return new Zipper(focus.Left, newCrumbs);
    }

    public Zipper? Right()
    {
        if (focus.Right is null) return null;

        List<Crumb> newCrumbs = [.. crumbs, new Crumb(focus.Value, focus.Left, false)];

        return new Zipper(focus.Right, newCrumbs);
    }

    public Zipper? Up()
    {
        if (crumbs.Count == 0) return null;

        var last = crumbs[^1];
        List<Crumb> newCrumbs = [.. crumbs];
        newCrumbs.RemoveAt(newCrumbs.Count - 1);

        var parent = last.CameFromLeft
            ? new BinTree(last.Value, focus, last.OtherChild)
            : new BinTree(last.Value, last.OtherChild, focus);

        return new Zipper(parent, newCrumbs);
    }

    public BinTree ToTree()
    {
        var current = this;

        while (current.Up() is Zipper parent)
        {
            current = parent;
        }

        return current.focus;
    }

    public static Zipper FromTree(BinTree tree) => new(tree, []);

    public bool Equals(Zipper? other)
    {
        if (other is null)
            return false;

        if (!Equals(focus, other.focus))
            return false;

        if (crumbs.Count != other.crumbs.Count)
            return false;

        for (int i = 0; i < crumbs.Count; i++)
        {
            var a = crumbs[i];
            var b = other.crumbs[i];

            if (a.Value != b.Value)
                return false;

            if (a.CameFromLeft != b.CameFromLeft)
                return false;

            if (!Equals(a.OtherChild, b.OtherChild))
                return false;
        }

        return true;
    }

    public override bool Equals(object? obj) =>
        Equals(obj as Zipper);

    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(focus);

        foreach (var crumb in crumbs)
        {
            hash.Add(crumb.Value);
            hash.Add(crumb.CameFromLeft);
            hash.Add(crumb.OtherChild);
        }

        return hash.ToHashCode();
    }
}