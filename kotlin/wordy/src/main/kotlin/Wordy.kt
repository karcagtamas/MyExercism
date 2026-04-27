import kotlin.math.pow

object Wordy {

    fun answer(input: String): Int {

        require(input.startsWith("What is ") && input.endsWith("?")) {
            "Unknows operation"
        }

        val tokens = input
            .removePrefix("What is ")
            .removeSuffix("?")
            .split(" ")

        if (tokens.isEmpty()) {
            throw IllegalArgumentException("Syntax error")
        }

        var index = 0

        var result = tokens[index++].toIntOrNull()
            ?: throw IllegalArgumentException("Syntax error")

        while (index < tokens.size) {
            val operation = when {
                tokens.getOrNull(index) == "plus" -> {
                    index++
                    "+"
                }

                tokens.getOrNull(index) == "minus" -> {
                    index++
                    "-"
                }

                tokens.getOrNull(index) == "multiplied" && tokens.getOrNull(index + 1) == "by" -> {
                    index += 2
                    "*"
                }

                tokens.getOrNull(index) == "divided" && tokens.getOrNull(index + 1) == "by" -> {
                    index += 2
                    "/"
                }

                tokens.getOrNull(index) == "raised" && tokens.getOrNull(index + 1) == "to" && tokens.getOrNull(index + 2) == "the" -> {
                    index += 3
                    "^"
                }

                else -> throw IllegalArgumentException("Unknow operation")
            }

            val number = when (operation) {
                "^" -> {
                    val token = tokens.getOrNull(index++)
                        ?: throw IllegalArgumentException("Syntax error")

                    val exponent = token.takeWhile { it.isDigit() }

                    require(exponent.isNotEmpty()) {
                        "Syntax error"
                    }

                    require(tokens.getOrNull(index++) == "power") {
                        "Syntax error"
                    }

                    exponent.toInt()
                }

                else -> tokens.getOrNull(index++)?.toIntOrNull()
                    ?: throw IllegalArgumentException("Syntax error")
            }

            result = when (operation) {
                "+" -> result + number
                "-" -> result - number
                "*" -> result * number
                "/" -> result / number
                "^" -> result.toDouble().pow(number).toInt()
                else -> error("Impossible")
            }
        }

        return result
    }
}
