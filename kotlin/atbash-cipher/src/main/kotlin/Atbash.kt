object Atbash {

    fun encode(s: String): String {
        return translate(s)
            .chunked(5)
            .joinToString(" ")
    }

    fun decode(s: String): String {
        return translate(s)
    }

    fun translate(s: String): String {
        return s
            .lowercase()
            .filter { it.isLetterOrDigit() }
            .map {
                when {
                    it.isLetter() -> ('z'.code - it.code + 'a'.code).toChar()
                    else -> it
                }
            }
            .joinToString("")
    }
}
