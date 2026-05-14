public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        if (list1.SequenceEqual(list2))
        {
            return SublistType.Equal;
        }

        if (list1.Count == 0)
        {
            return SublistType.Sublist;
        }

        if (list2.Count == 0)
        {
            return SublistType.Superlist;
        }

        if (ContainsSublist(list1, list2))
        {
            return SublistType.Superlist;
        }

        if (ContainsSublist(list2, list1))
        {
            return SublistType.Sublist;
        }

        return SublistType.Unequal;
    }

    private static bool ContainsSublist<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        var n = list1.Count;
        var m = list2.Count;

        if (m > n) return false;

        for (var i = 0; i <= n - m; i++)
        {
            var match = true;

            for (var j = 0; j < m; j++)
            {
                if (list1[i + j].CompareTo(list2[j]) != 0)
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                return true;
            }
        } 

        return false;
    }
}