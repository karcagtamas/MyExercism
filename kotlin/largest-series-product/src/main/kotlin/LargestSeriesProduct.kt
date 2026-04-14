class Series(private val input: String) {

    init {
        require(input.all { it.isDigit() })
    }

    fun getLargestProduct(span: Int): Long {
        require(input.length >= span)
        return input.windowed(span)
            .map { product(it) }
            .maxOf { it }
    }

    fun product(sec: String): Long {
        return sec
            .map { it.digitToInt().toLong() }
            .fold(1L, Long::times)
    }
}
