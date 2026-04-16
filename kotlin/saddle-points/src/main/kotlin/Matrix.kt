data class MatrixCoordinate(val row: Int, val col: Int)

class Matrix(m: List<List<Int>>) {

    val saddlePoints: Set<MatrixCoordinate>

    init {
        val points = mutableSetOf<MatrixCoordinate>()

        for (i in m.indices) {
            for (j in m[i].indices) {
                val maxInRow = m[i].all { it <= m[i][j] }
                val minInCol = m.map { it[j] }.all { it >= m[i][j] }

                if (maxInRow && minInCol) {
                    points.add(MatrixCoordinate(i + 1, j + 1))
                }
            }
        }

        saddlePoints = points.toSet()
    }
}