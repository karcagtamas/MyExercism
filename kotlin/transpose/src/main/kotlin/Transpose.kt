object Transpose {

    fun transpose(input: List<String>): List<String> {
        if (input.isEmpty()) return emptyList()

        val maxLen = input.maxOf { it.length }
        val result = mutableListOf<String>()

        for (col in 0 until maxLen) {
            val row = StringBuilder()

            for (line in input.indices) {
                val current = input[line]

                if (col < current.length) {
                    row.append(current[col])
                } else {
                    val needSpace = (line + 1 until input.size).any { col < input[it].length }

                    if (needSpace) {
                        row.append(' ')
                    }
                }
            }

            result.add(row.toString())
        }

        return result
    }
}
