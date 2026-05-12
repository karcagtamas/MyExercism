public record Tree(char Value, Tree? Left, Tree? Right);

public static class Satellite
{
    public static Tree? TreeFromTraversals(char[] preOrder, char[] inOrder)
    {
        if (preOrder.Length != inOrder.Length)
        {
            throw new ArgumentException();
        }

        if (preOrder.Distinct().Count() != preOrder.Length || inOrder.Distinct().Count() != inOrder.Length)
        {
            throw new ArgumentException();
        }

        return Build(preOrder, inOrder);
    }

    private static Tree? Build(char[] preOrder, char[] inOrder)
    {
        if (preOrder.Length == 0)
        {
            return null;
        }

        var rootValue = preOrder[0];
        var rootIndex = Array.IndexOf(inOrder, rootValue);

        if (rootIndex < 0)
        {
            throw new ArgumentException();
        }

        var leftInOrder = inOrder[..rootIndex];
        var rightInOrder = inOrder[(rootIndex + 1)..];

        var leftPreOrder = preOrder[1..(1 + leftInOrder.Length)];
        var rightPreOrder = preOrder[(1 + leftInOrder.Length)..];

        return new Tree(
            rootValue,
            Build(leftPreOrder, leftInOrder),
            Build(rightPreOrder, rightInOrder)
        );
    }
}
