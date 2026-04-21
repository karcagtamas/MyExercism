object PigLatin {

    private val vowels = arrayOf('a', 'e', 'i', 'o', 'u')

    fun translate(phrase: String): String {
        return phrase
            .split(" ")
            .joinToString(" ") { translateWord(it) }
    }

    private fun translateWord(word: String): String {
        val idx = firstConsonantClusterEnd(word)
        val quIndex = word.indexOf("qu")
        val yIndex = word.indexOf('y')

        return when {
            word[0] in vowels || word.startsWith("xr") || word.startsWith("yt") -> word + "ay"

            quIndex != -1 && quIndex < idx ->
                word.substring(quIndex + 2) +
                        word.substring(0, quIndex + 2) + "ay"

            yIndex > 0 && word.substring(0, yIndex)
                .all { it !in vowels } -> word.substring(yIndex) + word.substring(0, yIndex) + "ay"

            else -> word.substring(idx) + word.substring(0, idx) + "ay"
        }
    }

    private fun firstConsonantClusterEnd(word: String): Int {
        for (i in word.indices) {
            if (word[i] in vowels) return i
        }
        return word.length
    }
}
