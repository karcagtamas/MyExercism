object PrimeFactorCalculator {

    fun primeFactors(int: Int): List<Int> {
        return primeFactors(int.toLong()).map { it.toInt() }
    }

    fun primeFactors(long: Long): List<Long> {
        var value = long
        val factors = mutableListOf<Long>()

        while (value % 2L == 0L) {
            factors.add(2L)
            value /= 2L
        }

        var n = 3L

        while (n * n <= value) {
            while (value % n == 0L) {
                factors.add(n)
                value /= n
            }
            n += 2
        }

        if (value > 1) {
            factors.add(value)
        }

        return factors
    }
}
