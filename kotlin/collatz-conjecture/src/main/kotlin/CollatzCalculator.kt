object CollatzCalculator {
    fun computeStepCount(start: Int): Int {
        require(start > 0)

        if (start == 1) {
            return 0
        }

        return (if (start % 2 == 0) computeStepCount(start / 2) else computeStepCount(start * 3 + 1)) + 1
    }
}
