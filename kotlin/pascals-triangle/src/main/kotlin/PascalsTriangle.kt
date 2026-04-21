object PascalsTriangle {

    fun computeTriangle(rows: Int): List<List<Int>> {
        val triangle = Array(rows) { IntArray(rows) }

        for (i in triangle.indices) {
            for (j in 0..i) {
                when {
                    j == 0 -> triangle[i][j] = 1
                    j == i -> triangle[i][j] = 1
                    else -> triangle[i][j] = triangle[i - 1][j] + triangle[i - 1][j - 1]
                }
            }
        }

        return triangle.map { it.toList().filter { it -> it != 0 } }
    }
}
