object BottleSong {

    private val numbers = listOf(
        "no", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
    )

    fun recite(startBottles: Int, takeDown: Int): String {
        return (startBottles downTo startBottles - takeDown + 1)
            .joinToString("\n\n") { verse(it) }
    }

    private fun verse(n: Int): String {
        val current = bottles(n)
        val next = bottles(n - 1)

        return """
            ${capitalize(current)} hanging on the wall,
            ${capitalize(current)} hanging on the wall,
            And if one green bottle should accidentally fall,
            There'll be $next hanging on the wall.
        """.trimIndent()
    }

    private fun bottles(n: Int): String {
        val word = numbers[n]
        val bottle = if (n == 1) "green bottle" else "green bottles"
        return "$word $bottle"
    }

    private fun capitalize(text: String): String = text.replaceFirstChar { it.uppercase() }
}
