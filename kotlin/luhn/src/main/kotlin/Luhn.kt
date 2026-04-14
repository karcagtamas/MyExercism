object Luhn {

    fun isValid(candidate: String): Boolean {
        var sum = 0
        var count = 0
        var double = false

        for (i in candidate.length - 1 downTo 0) {
            val ch = candidate[i]

            if (ch == ' ') continue
            if (!ch.isDigit()) return false

            var digit = ch - '0'

            if (double) {
                digit *= 2
                if (digit > 9) digit -= 9
            }

            sum += digit
            double = !double
            count++
        }

        return count > 1 && sum % 10 == 0
    }
}
