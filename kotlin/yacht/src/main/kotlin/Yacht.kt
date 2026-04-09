object Yacht {

    fun solve(category: YachtCategory, vararg dices: Int): Int {
        val counts = IntArray(7)
        var sum = 0

        for (d in dices) {
            counts[d]++
            sum += d
        }

        var has3 = false
        var has2 = false
        var fourValue = 0
        var yacht = false

        for (face in 1..6) {
            when (counts[face]) {
                5 -> {
                    yacht = true
                    fourValue = face   // <-- important fix
                }
                4 -> fourValue = face
                3 -> has3 = true
                2 -> has2 = true
            }
        }

        return when (category) {

            YachtCategory.YACHT ->
                if (yacht) 50 else 0

            YachtCategory.ONES -> counts[1]
            YachtCategory.TWOS -> counts[2] * 2
            YachtCategory.THREES -> counts[3] * 3
            YachtCategory.FOURS -> counts[4] * 4
            YachtCategory.FIVES -> counts[5] * 5
            YachtCategory.SIXES -> counts[6] * 6

            YachtCategory.FULL_HOUSE ->
                if (has3 && has2) sum else 0

            YachtCategory.FOUR_OF_A_KIND ->
                if (fourValue != 0) fourValue * 4 else 0

            YachtCategory.LITTLE_STRAIGHT ->
                if (
                    counts[1] == 1 &&
                    counts[2] == 1 &&
                    counts[3] == 1 &&
                    counts[4] == 1 &&
                    counts[5] == 1
                ) 30 else 0

            YachtCategory.BIG_STRAIGHT ->
                if (
                    counts[2] == 1 &&
                    counts[3] == 1 &&
                    counts[4] == 1 &&
                    counts[5] == 1 &&
                    counts[6] == 1
                ) 30 else 0

            YachtCategory.CHOICE -> sum
        }
    }
}