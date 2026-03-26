object Isogram {

    fun isIsogram(input: String): Boolean {
        val letters = input.filter { it.isLetter() }.map { it.lowercaseChar() }
        return letters.size == letters.distinct().size
    }
}
