class Forth {

    private val stack = mutableListOf<Int>()
    private val definitions = mutableMapOf<String, List<String>>()

    fun evaluate(vararg line: String): List<Int> {

        val tokens = line
            .flatMap { it.lowercase().split("\\s+".toRegex()) }
            .filter { it.isNotBlank() }

        process(tokens)

        return stack.toList()
    }

    private fun process(tokens: List<String>) {
        var i = 0
        while (i < tokens.size) {
            when (val token = tokens[i]) {

                ":" -> {
                    val name = tokens.getOrNull(i + 1)
                        ?: throw IllegalArgumentException("Invalid token $token")
                    require(name.toIntOrNull() == null) { "illegal operation" }

                    val body = mutableListOf<String>()

                    i += 2

                    while (i < tokens.size && tokens[i] != ";") {
                        body += tokens[i]
                        i++
                    }

                    if (i >= tokens.size) {
                        throw IllegalArgumentException("Invalid token $token")
                    }

                    definitions[name] = expand(body)
                }

                else -> execute(token)
            }

            i++
        }
    }

    private fun execute(token: String) {
        token.toIntOrNull()?.let {
            stack.add(it)
            return
        }

        definitions[token]?.let {
            process(it)
            return
        }

        when (token) {
            "+" -> {
                val (a, b) = pop2()
                stack += a + b
            }

            "-" -> {
                val (a, b) = pop2()
                stack += a - b
            }

            "*" -> {
                val (a, b) = pop2()
                stack += a * b
            }

            "/" -> {
                val (a, b) = pop2()
                require(b != 0) { "divide by zero" }
                stack += a / b
            }

            "dup" -> {
                require(stack.isNotEmpty()) { "empty stack" }
                stack += stack.last()
            }

            "drop" -> {
                require(stack.isNotEmpty()) { "empty stack" }
                stack.removeAt(stack.lastIndex)
            }

            "swap" -> {
                require(stack.isNotEmpty()) { "empty stack" }
                require(stack.size >= 2) { "only one value on the stack" }

                val a = stack.removeAt(stack.lastIndex)
                val b = stack.removeAt(stack.lastIndex)

                stack += a
                stack += b
            }

            "over" -> {
                require(stack.isNotEmpty()) { "empty stack" }
                require(stack.size >= 2) { "only one value on the stack" }
                stack += stack[stack.lastIndex - 1]
            }

            else -> throw IllegalArgumentException("undefined operation")
        }
    }

    private fun pop2(): Pair<Int, Int> {
        require(stack.isNotEmpty()) { "empty stack" }
        require(stack.size >= 2) { "only one value on the stack" }

        val b = stack.removeAt(stack.lastIndex)
        val a = stack.removeAt(stack.lastIndex)

        return a to b
    }

    private fun expand(tokens: List<String>): List<String> {
        val result = mutableListOf<String>()

        for (token in tokens) {
            result += definitions[token] ?: listOf(token)
        }

        return result
    }
}
