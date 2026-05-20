public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target < 0)
        {
            throw new ArgumentException("Negative totals are not allowed");
        }

        if (target == 0) return [];

        var dp = new List<int>?[target + 1];
        dp[0] = [];

        for (var amount = 1; amount <= target; amount++)
        {
            List<int>? best = null;

            foreach (var coin in coins)
            {
                if (coin <= amount)
                {
                    var prev = dp[amount - coin];

                    if (prev != null)
                    {
                        List<int> candidate = [.. prev, coin];

                        if (best == null || candidate.Count < best.Count)
                        {
                            best = candidate;
                        }
                    }
                }
            }

            dp[amount] = best;
        }

        var result = dp[target]?.ToList() ?? null;
        if (result != null)
        {
            result.Sort();
            return [.. result];
        }

        throw new ArgumentException($"The total {target} cannot be represented in the given currency");
    }
}