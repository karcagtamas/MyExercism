import kotlin.to

object ScrabbleScore {

    private val scores = mapOf(
        1 to listOf('A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'),
        2 to listOf('D', 'G'),
        3 to listOf('B', 'C', 'M', 'P'),
        4 to listOf('F', 'H', 'V', 'W', 'Y'),
        5 to listOf('K'),
        8 to listOf('J', 'X'),
        10 to listOf('Q', 'Z'),
    )

    fun scoreLetter(c: Char): Int {
        return scores.filter { it.value.contains(c) }
            .map { it.key }
            .sum()
    }

    fun scoreWord(word: String): Int {
        return word.uppercase().map { scoreLetter(it) }.sum()
    }
}
