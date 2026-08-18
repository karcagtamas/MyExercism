import java.util.List;

class Knapsack {

    int maximumValue(int maximumWeight, List<Item> items) {
        var n = items.size();
        var dp = new int[n + 1][maximumWeight + 1];

        for (var i = 1; i <= n; i++) {
            var item = items.get(i - 1);

            for (var w = 0; w <= maximumWeight; w++) {
                dp[i][w] = dp[i - 1][w];

                if (item.weight <= w) {
                    dp[i][w] = Math.max(dp[i][w], dp[i - 1][w - item.weight] + item.value);
                }
            }
        }

        return dp[n][maximumWeight];
    }

}