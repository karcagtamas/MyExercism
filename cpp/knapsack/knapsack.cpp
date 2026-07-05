#include "knapsack.h"

namespace knapsack
{

    int maximum_value(int max_weight, const std::vector<knapsack::Item> &items)
    {
        int n = static_cast<int>(items.size());
        std::vector<std::vector<int>> dp(n + 1, std::vector<int>(max_weight + 1, 0));

        for (int i = 1; i <= n; i++)
        {
            int weight = items[i - 1].weight;
            int value = items[i - 1].value;

            for (int w = 0; w <= max_weight; w++)
            {
                dp[i][w] = dp[i - 1][w];

                if (weight <= w)
                {
                    dp[i][w] = std::max(dp[i][w], dp[i - 1][w - weight] + value);
                }
            }
        }

        return dp[n][max_weight];
    }

} // namespace knapsack
