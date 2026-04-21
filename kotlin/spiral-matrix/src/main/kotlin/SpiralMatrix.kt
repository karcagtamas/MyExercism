object SpiralMatrix {

    fun ofSize(size: Int): Array<IntArray> {
        val matrix = Array(size) { IntArray(size) }

        var top = 0
        var bottom = size - 1
        var left = 0
        var right = size - 1

        var num = 1

        while (top <= bottom && left <= right) {

            for (col in left..right) {
                matrix[top][col] = num++
            }
            top++

            for (row in top..bottom) {
                matrix[row][right] = num++
            }
            right--

            if (top <= bottom) {
                for (col in right downTo left) {
                    matrix[bottom][col] = num++
                }
                bottom--
            }

            if (left <= right) {
                for (row in bottom downTo top) {
                    matrix[row][left] = num++
                }
                left++
            }
        }

        return matrix
    }
}
