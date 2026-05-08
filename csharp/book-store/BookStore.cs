public static class BookStore
{
    private static readonly Dictionary<int, decimal> Discounts = new()
    {
        [1] = 1.00m,
        [2] = 0.95m,
        [3] = 0.90m,
        [4] = 0.80m,
        [5] = 0.75m,
    };

    private static readonly Dictionary<string, decimal> Memo = new();

    public static decimal Total(IEnumerable<int> books)
    {
        var counts = books
            .GroupBy(x => x)
            .Select(g => g.Count())
            .OrderByDescending(x => x)
            .ToArray();

        return Solve(counts);
    }

    private static decimal Solve(int[] counts)
    {
        counts = counts
            .Where(x => x > 0)
            .OrderByDescending(x => x)
            .ToArray();

        if (counts.Length == 0) return 0m;

        var key = string.Join(",", counts);

        if (Memo.TryGetValue(key, out var cached))
        {
            return cached;
        }

        var best = decimal.MaxValue;
        var maxGroupSize = counts.Length;

        for (var size = 1; size <= maxGroupSize; size++)
        {
            var next = (int[])counts.Clone();

            for (var i = 0; i < size; i++)
            {
                next[i]--;
            }

            var groupPrice = size * 8m * Discounts[size];
            best = Math.Min(best, groupPrice + Solve(next));
        }

        Memo[key] = best;

        return best;
    }
}