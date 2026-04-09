object Yacht {

    fun solve(category: YachtCategory, vararg dices: Int): Int {
        val counts = IntArray(7)
        var sum = 0

        for (d in dices) {
            counts[d]++
            sum += d
        }

        return when (category) {

            YachtCategory.YACHT ->
                if (counts.any { it == 5 }) 50 else 0

            YachtCategory.ONES -> counts[1]
            YachtCategory.TWOS -> counts[2] * 2
            YachtCategory.THREES -> counts[3] * 3
            YachtCategory.FOURS -> counts[4] * 4
            YachtCategory.FIVES -> counts[5] * 5
            YachtCategory.SIXES -> counts[6] * 6

            YachtCategory.FULL_HOUSE ->
                if (counts.containsFullHouse()) sum else 0

            YachtCategory.FOUR_OF_A_KIND ->
                (6 downTo 1).maxOf { face ->
                    if (counts[face] >= 4) face * 4 else 0
                }

            YachtCategory.LITTLE_STRAIGHT ->
                if (countsMatches(counts, 1, 2, 3, 4, 5)) 30 else 0

            YachtCategory.BIG_STRAIGHT ->
                if (countsMatches(counts, 2, 3, 4, 5, 6)) 30 else 0

            YachtCategory.CHOICE -> sum
        }
    }

    private fun IntArray.containsFullHouse(): Boolean {
        var has3 = false
        var has2 = false

        for (c in this) {
            if (c == 3) has3 = true
            if (c == 2) has2 = true
        }

        return has3 && has2
    }

    private fun countsMatches(counts: IntArray, vararg faces: Int): Boolean {
        for (f in faces) {
            if (counts[f] != 1) return false
        }
        return true
    }
}