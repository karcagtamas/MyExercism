class ChangeCalculator(private val coins: List<Int>) {

    fun computeMostEfficientChange(grandTotal: Int): List<Int> {
        require(grandTotal >= 0) { "Negative totals are not allowed." }

        if (grandTotal == 0) return emptyList()

        val dp = Array<List<Int>?>(grandTotal + 1) { null }
        dp[0] = emptyList()

        for (amount in 1..grandTotal) {
            var best: List<Int>? = null

            for (coin in coins) {
                if (coin <= amount) {
                    val prev = dp[amount - coin]

                    if (prev != null) {
                        val candidate = prev + coin

                        if (best == null || candidate.size < best.size) {
                            best = candidate
                        }
                    }
                }
            }

            dp[amount] = best
        }

        return dp[grandTotal]?.sorted()
            ?: throw IllegalArgumentException("The total $grandTotal cannot be represented in the given currency.")
    }
}
