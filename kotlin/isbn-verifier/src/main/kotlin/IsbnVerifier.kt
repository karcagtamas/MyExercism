class IsbnVerifier {

    fun isValid(number: String): Boolean {
        var sum = 0
        var count = 0

        for (ch in number) {
            if (ch == '-') continue

            count++

            val value = when {
                ch.isDigit() -> ch - '0'
                ch == 'X' && count == 10 -> 10
                else -> return false
            }

            sum += value * (11 - count)
        }

        return count == 10 && sum % 11 == 0
    }
}
