data class Item(val weight: Int, val value: Int)

fun knapsack(maximumWeight: Int, items: List<Item>): Int {
    val n = items.size
    val dp = Array(n + 1) { IntArray(maximumWeight + 1) }

    for (i in 1..n) {
        val (weight, value) = items[i - 1]

        for (w in 0..maximumWeight) {
            dp[i][w] = dp[i - 1][w]

            if (weight <= w) {
                dp[i][w] = maxOf(dp[i][w], dp[i - 1][w - weight] + value)
            }
        }
    }

    return dp[n][maximumWeight]
}
