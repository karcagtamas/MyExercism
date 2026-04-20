object MatchingBrackets {

    fun isValid(input: String): Boolean {
        val stack = ArrayDeque<Char>()

        val pairs = mapOf(
            ')' to '(',
            '}' to '{',
            ']' to '[',
        )

        for (ch in input) {
            when (ch) {
                in pairs.values -> stack.addLast(ch)
                in pairs.keys -> {
                    if (stack.isEmpty() || stack.removeLast() != pairs[ch]) {
                        return false
                    }
                }
            }
        }

        return stack.isEmpty()
    }
}
