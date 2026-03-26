object ETL {
    fun transform(source: Map<Int, Collection<Char>>): Map<Char, Int> =
        source.map { it.value.map { v -> v.lowercaseChar() to it.key } }
            .flatten()
            .toMap()
}
