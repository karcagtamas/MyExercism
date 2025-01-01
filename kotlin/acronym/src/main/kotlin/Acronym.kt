object Acronym {
    fun generate(phrase: String): String {
        return phrase.split(Regex("[ _-]+"))
            .joinToString("") { it.first().uppercaseChar().toString() }
    }
}
