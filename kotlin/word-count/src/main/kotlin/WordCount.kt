object WordCount {

    private val regex = Regex("""[A-Za-z0-9]+(?:'[A-Za-z0-9]+)*""")

    fun phrase(phrase: String): Map<String, Int> {
        val words = mutableMapOf<String, Int>()
        val input = phrase.lowercase()

        for (match in regex.findAll(input)) {
            val word = match.value
            words[word] = (words[word] ?: 0) + 1
        }

        return words
    }
}