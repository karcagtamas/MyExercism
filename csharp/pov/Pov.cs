public class Tree(string value, params Tree[] children)
{
    public string Value { get; private set; } = value;
    public Tree[] Children { get; private set; } = children;

    public override bool Equals(object? obj)
    {
        if (obj is not Tree other)
            return false;

        if (!Value.Equals(other.Value))
            return false;

        if (Children.Length != other.Children.Length)
            return false;

        var thisChildrenCounts = Children.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        var otherChildrenCounts = other.Children.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

        if (thisChildrenCounts.Count != otherChildrenCounts.Count)
            return false;

        foreach (var kvp in thisChildrenCounts)
        {
            if (!otherChildrenCounts.TryGetValue(kvp.Key, out int count) || count != kvp.Value)
                return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        int hash = Value.GetHashCode();
        foreach (var child in Children)
        {
            hash += child.GetHashCode();
        }
        return hash;
    }
}

public static class Pov
{
    public static Tree FromPov(Tree tree, string from)
    {
        var path = FindPath(tree, from);
        if (path == null)
        {
            throw new ArgumentException("Target node not found.");
        }

        return ReparentPath(path, path.Count - 1);
    }

    public static IEnumerable<string> PathTo(string from, string to, Tree tree)
    {
        Tree reparentedTree;
        try
        {
            reparentedTree = FromPov(tree, from);
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Source node not found.");
        }

        var path = FindPath(reparentedTree, to);
        if (path == null)
        {
            throw new ArgumentException("Destination node not found.");
        }

        return path.Select(node => node.Value);
    }

    private static List<Tree>? FindPath(Tree current, string target)
    {
        if (current.Value == target)
        {
            return [current];
        }

        foreach (var child in current.Children)
        {
            var path = FindPath(child, target);
            if (path != null)
            {
                path.Insert(0, current);
                return path;
            }
        }

        return null;
    }

    private static Tree ReparentPath(List<Tree> path, int index)
    {
        var current = path[index];

        if (index == path.Count - 1)
        {
            var reversedChildren = current.Children.Reverse();

            if (index > 0)
            {
                var newParent = ReparentPath(path, index - 1);
                return new Tree(current.Value, [.. reversedChildren, newParent]);
            }

            return new Tree(current.Value, reversedChildren.ToArray());
        }

        string excludeChildValue = path[index + 1].Value;
        var filteredChildren = current.Children.Where(child => child.Value != excludeChildValue);

        if (index > 0)
        {
            var newParent = ReparentPath(path, index - 1);
            return new Tree(current.Value, [.. filteredChildren, newParent]);
        }

        return new Tree(current.Value, [.. filteredChildren]);
    }
}