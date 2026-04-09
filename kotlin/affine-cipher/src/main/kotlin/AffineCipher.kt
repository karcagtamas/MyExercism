object AffineCipher {

    private val m = 26

    // E(x) = (ai + b) mod m
    fun encode(input: String, a: Int, b: Int): String {
        require(gcd(a, m) == 1)
        val cleaned = input.lowercase().filter { it.isLetterOrDigit() }
        val transformed = buildString {
            for (ch in cleaned) {
                when {
                    ch.isDigit() -> append(ch)
                    ch.isLetter() -> {
                        val x = ch - 'a'
                        val y = (a * x + b) % m
                        append(('a'.code + y).toChar())
                    }
                }
            }
        }

        return transformed.chunked(5).joinToString(" ")
    }

    fun decode(input: String, a: Int, b: Int): String {
        // D(y) = (a^-1)(y - b) mod m
        val aInv = modInverse(a, m)
        val cleaned = input.lowercase().filter { it.isLetterOrDigit() }

        return buildString {
            for (ch in cleaned) {
                when {
                    ch.isDigit() -> append(ch)
                    ch.isLetter() -> {
                        val y = ch - 'a'
                        val x = (aInv * (y - b).mod(m)) % m
                        append(('a'.code + x).toChar())
                    }
                }
            }
        }
    }

    private fun gcd(x: Int, y: Int): Int {
        var a = x
        var b = y

        while (b != 0) {
            val t = b
            b = a % b
            a = t
        }
        return a
    }

    private fun modInverse(a: Int, m: Int): Int {
        for (x in 1 until m) {
            if ((a * x) % m == 1) return x
        }

        throw IllegalArgumentException("No modular inverse exists")
    }
}
