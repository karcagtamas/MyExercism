class RailFenceCipher(private val rails: Int) {

    fun getEncryptedData(input: String): String {
        if (rails == 0) return input

        val rows = Array(rails) { StringBuilder() }

        var rail = 0
        var direction = 1

        for (c in input) {
            rows[rail].append(c)
            if (rail == 0) {
                direction = 1
            } else if (rail == rails - 1) {
                direction = -1
            }

            rail += direction
        }

        return rows.joinToString("") { it.toString() }
    }

    fun getDecryptedData(input: String): String {
        if (rails == 1) return input

        val pattern = IntArray(input.length)

        var rail = 0
        var direction = 1

        for (i in input.indices) {
            pattern[i] = rail

            if (rail == 0) {
                direction = 1
            } else if (rail == rails - 1) {
                direction = -1
            }

            rail += direction
        }

        val counts = IntArray(rails)
        for (r in pattern) {
            counts[r]++
        }

        val railChars = Array(rails) { CharArray(counts[it]) }
        var index = 0

        for (r in 0 until rails) {
            for (i in railChars[r].indices) {
                railChars[r][i] = input[index++]
            }
        }

        val railIndices = IntArray(rails)
        return buildString {
            for (r in pattern) {
                append(railChars[r][railIndices[r]++])
            }
        }
    }
}
