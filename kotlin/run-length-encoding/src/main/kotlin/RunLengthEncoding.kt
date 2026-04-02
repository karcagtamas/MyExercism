object RunLengthEncoding {

    fun encode(input: String): String {
        if (input.isEmpty()) {
            return input
        }

        val res = StringBuilder(input.length)

        var latest = input[0]
        var count = 1
        for (i in (1 until input.length)) {
            if (input[i] == latest) {
                count++
            } else {
                if (count > 1) res.append(count)
                res.append(latest)

                latest = input[i]
                count = 1
            }
        }

        if (count > 1) res.append(count)
        res.append(latest)

        return res.toString()
    }

    fun decode(input: String): String {
        if (input.isEmpty()) {
            return input
        }

        val res = StringBuilder()
        var count = 0

        for (c in input) {
            if (c.isDigit()) {
                count = count * 10 + (c - '0')
            } else {
                val repeat = if (count == 0) 1 else count
                repeat(repeat) { res.append(c) }
                count = 0
            }
        }

        return res.toString()
    }
}
