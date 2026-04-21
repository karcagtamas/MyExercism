class Robot {

    companion object {
        private val usedNames = mutableSetOf<String>()
        private val letters = ('A'..'Z').toList()
        private val digits = ('0'..'9').toList()
    }

    var name: String = generateUniqueName()
        private set

    fun reset() {
        name = generateUniqueName()
    }

    private fun generateUniqueName(): String {
        while (true) {
            val newName = buildString {
                repeat(2) { append(letters.random()) }
                repeat(3) { append(digits.random()) }
            }

            if (usedNames.add(newName)) {
                return newName
            }
        }
    }
}
