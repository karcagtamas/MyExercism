object PrimeFactorCalculator {

    fun primeFactors(int: Int): List<Int> {
        return primeFactors(int.toLong()).map { it.toInt() }
    }

    fun primeFactors(long: Long): List<Long> {
        var value = long

        var n = 2L
        val factors = mutableListOf<Long>()
        while (value > 1L) {
            if (value % n == 0L) {
                value /= n
                factors.add(n)
            } else {
                n += 1
            }
        }

        return factors
    }
}
