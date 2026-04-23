object Transpose {

    fun transpose(input: List<String>): List<String> {
        if (input.isEmpty()) return emptyList()

        val maxLen = input.maxOf { it.length }

        // last row index that has a char for each column
        val lastRowWithChar = IntArray(maxLen)

        for (col in 0 until maxLen) {
            for (row in input.indices.reversed()) {
                if (col < input[row].length) {
                    lastRowWithChar[col] = row
                    break
                }
            }
        }

        val result = mutableListOf<String>()

        for (col in 0 until maxLen) {
            val sb = StringBuilder()

            for (row in input.indices) {
                if (col < input[row].length) {
                    sb.append(input[row][col])
                } else if (row < lastRowWithChar[col]) {
                    sb.append(' ')
                }
            }

            result.add(sb.toString())
        }

        return result
    }
}
