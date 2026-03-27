class Anagram(val source: String) {

    val sortedSource = source.sortedString()

    fun match(anagrams: Collection<String>): Set<String> {
        return anagrams
            .filter {
                sortedSource.equals(it.sortedString(), ignoreCase = true)
            }
            .filter {
                it.lowercase() != source.lowercase()
            }
            .toSet()
    }

    private fun String.sortedString(): String = this.lowercase().toCharArray().sorted().joinToString("")
}
