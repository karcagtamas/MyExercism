object Bob {
    fun hey(input: String): String {
        if (input.trim().isEmpty()) {
            return "Fine. Be that way!"
        }

        val isYelling = input.all { !it.isLetter() || it.isUpperCase() } && input.any { it.isLetter() }
        val isQuestion = input.trimEnd().last() == '?'
        if (isYelling && isQuestion) {
            return "Calm down, I know what I'm doing!"
        }

        if (isQuestion) {
            return "Sure."
        }

        if (isYelling) {
            return "Whoa, chill out!"
        }

        return "Whatever."
    }
}
