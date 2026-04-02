class RotationalCipher(private val rot: Int) {

    fun encode(text: String): String {
        return text
            .map { encode(it) }
            .joinToString("")
    }

    fun encode(char: Char): Char {
        return when (char) {
            in 'a'..'z' -> ((char - 'a' + rot) % 26 + 'a'.code).toChar()
            in 'A'..'Z' -> ((char - 'A' + rot) % 26 + 'A'.code).toChar()
            else -> char
        }
    }
}
