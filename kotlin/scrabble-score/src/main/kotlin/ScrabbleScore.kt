import kotlin.to

object ScrabbleScore {

    private val scores = IntArray(26).apply {
        "AEIOULNRST".forEach { this[it - 'A'] = 1 }
        "DG".forEach { this[it - 'A'] = 2 }
        "BCMP".forEach { this[it - 'A'] = 3 }
        "FHVWY".forEach { this[it - 'A'] = 4 }
        "K".forEach { this[it - 'A'] = 5 }
        "JX".forEach { this[it - 'A'] = 8 }
        "QZ".forEach { this[it - 'A'] = 10 }
    }

    fun scoreLetter(c: Char): Int {
        return scores[c - 'A']
    }

    fun scoreWord(word: String): Int {
        return word.uppercase().map { scoreLetter(it) }.sum()
    }
}
