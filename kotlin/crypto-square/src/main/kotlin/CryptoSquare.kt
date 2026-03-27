object CryptoSquare {

    fun ciphertext(plaintext: String): String {
        val normalized = plaintext.filter { it.isLetter() || it.isDigit() }.lowercase()
        val (r, c) = rectangle(normalized)

        return (0 until c).joinToString(" ") { i ->
            (0 until r).joinToString("") { j ->
                val index = j * c + i

                (if (index < normalized.length) {
                    normalized[index]
                } else {
                    ' '
                }).toString()
            }
        }
    }

    private fun rectangle(normalized: String): Pair<Int, Int> {
        val n = normalized.length
        var r = 1
        var c = n

        for (i in 1..n) {
            val rows = i
            val cols = (n + rows - 1) / rows

            if (cols >= rows && cols - rows <= 1) {
                r = rows
                c = cols
                break
            }
        }

        return Pair(r, c)
    }

}
