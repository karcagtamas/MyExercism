public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes) => dominoes.ToList().Count == 0 
        || Backtrack([dominoes.First()], [.. dominoes.Skip(1)]) != null;

    private static List<(int, int)>? Backtrack(List<(int, int)> chain, List<(int, int)> remaining)
    {
        if (remaining.Count == 0)
        {
            return chain[0].Item1 == chain[^1].Item2 ? chain : null;
        }

        var end = chain[^1].Item2;

        for (var i = 0; i < remaining.Count; i++)
        {
            var d = remaining[i];
            var nextRemaining = remaining.Take(i).Concat(remaining.Skip(i + 1)).ToList();

            if (d.Item1 == end)
            {
                var result = Backtrack([.. chain, d], nextRemaining);

                if (result != null) return result;
            }

            if (d.Item2 == end)
            {
                var flipped = (d.Item2, d.Item1);
                var result = Backtrack([.. chain, flipped], nextRemaining);

                if (result != null) return result;
            }
        }

        return null;
    }
}