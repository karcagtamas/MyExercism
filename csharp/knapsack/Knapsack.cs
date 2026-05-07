public static class Knapsack
{
    public static int MaximumValue(int maximumWeight, (int weight, int value)[] items)
    {
        var n = items.Length;
        var dp = new int[n + 1, maximumWeight + 1];

        for (var i = 1; i <= n; i++)
        {
            var (weight, value) = items[i - 1];

            for (var w = 0; w <= maximumWeight; w++)
            {
                dp[i, w] = dp[i - 1, w];

                if (weight <= w)
                {
                    dp[i, w] = Math.Max(dp[i, w], dp[i - 1, w - weight] + value);
                }
            }
        }

        return dp[n, maximumWeight];
    }
}
