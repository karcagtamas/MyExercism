import kotlin.random.Random

data class Cipher(
    val key: String = generateKey()
) {

    companion object {
        fun generateKey(length: Int = 100): String {
            return buildString {
                repeat(length) {
                    append(('a'.code + Random.nextInt(26)).toChar())
                }
            }
        }
    }

    init {
        require(key.isNotEmpty())
        require(key.all { it in 'a'..'z' })
    }

    fun encode(s: String): String {
        return transform(s, true)
    }

    fun decode(s: String): String {
        return transform(s, false)
    }

    private fun transform(text: String, encode: Boolean): String {
        val result = StringBuilder(text.length)

        for (i in text.indices) {
            val textOffset = text[i] - 'a'
            val keyOffset = key[i % key.length] - 'a'

            val shifted = if (encode) {
                (textOffset + keyOffset) % 26
            } else {
                (textOffset - keyOffset + 26) % 26
            }

            result.append(('a'.code + shifted).toChar())
        }

        return result.toString()
    }
}
