class Matrix(private val matrixAsString: String) {

    private val m: List<List<Int>> = matrixAsString.split("\n")
        .map { r ->
            r.split(" ")
                .map { i ->
                    i.toInt()
                }
        }

    fun column(colNr: Int): List<Int> {
        return m.map { it[colNr - 1] }
    }

    fun row(rowNr: Int): List<Int> {
        return m[rowNr - 1]
    }
}
