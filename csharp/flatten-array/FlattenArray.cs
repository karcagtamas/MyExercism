using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach (var item in input)
        {
            if (item is null)
            {
                continue;
            }

            if (item is string)
            {
                yield return item;
            }
            else if (item is IEnumerable nested)
            {
                foreach (var inner in Flatten(nested))
                {
                    yield return inner;
                }
            }
            else
            {
                yield return item;
            }
        }
    }
}