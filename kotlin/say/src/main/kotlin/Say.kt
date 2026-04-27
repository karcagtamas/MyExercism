class NumberSpeller {

    private val small = listOf(
        "zero",
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine",
        "ten",
        "eleven",
        "twelve",
        "thirteen",
        "fourteen",
        "fifteen",
        "sixteen",
        "seventeen",
        "eighteen",
        "nineteen",
    )
    private val tens = listOf("", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety")
    private val scales = listOf("", "thousand", "million", "billion")

    fun say(input: Long): String {

        require(input in 0..999_999_999_999) {
            "Number out of range"
        }

        if (input == 0L) return "zero"

        var number = input
        var scaleIndex = 0
        val parts = mutableListOf<String>()

        while (number > 0) {
            val chunk = (number % 1000).toInt()

            if (chunk != 0) {
                val chunkText = sayUnder1000(chunk)
                val scale = scales[scaleIndex]

                parts += if (scale.isEmpty()) {
                    chunkText
                } else {
                    "$chunkText $scale"
                }
            }

            number /= 1000
            scaleIndex++
        }

        return parts.asReversed().joinToString(" ")
    }

    private fun sayUnder1000(number: Int): String {
        val parts = mutableListOf<String>()

        val hundreds = number / 100
        val remainder = number % 100

        if (hundreds > 0) {
            parts += "${small[hundreds]} hundred"
        }

        if (remainder > 0) {
            val text = when {
                remainder < 20 -> small[remainder]

                remainder % 10 == 0 -> {
                    tens[remainder / 10]
                }

                else -> {
                    "${tens[remainder / 10]}-${small[remainder % 10]}"
                }
            }

            parts += text
        }

        return parts.joinToString(" ")
    }
}
