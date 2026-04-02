class RotationalCipher(private val rot: Int) {

    fun encode(text: String): String {
        return text
            .map { if (it.isLetter()) encode(it) else it }
            .joinToString("")
    }

    fun encode(char: Char): Char {
        val a = if (char.isUpperCase()) 'A'.code else 'a'.code
        val z = if (char.isUpperCase()) 'Z'.code else 'z'.code

        return (((char.code - a + rot) % (z - a + 1)) + a).toChar()
    }
}
