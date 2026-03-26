object SumOfMultiples {

    fun sum(factors: Set<Int>, limit: Int): Int {
        return factors
            .filter { it > 0 }
            .flatMap {
                0 until limit step it
            }
            .distinct()
            .sum()
    }
}
