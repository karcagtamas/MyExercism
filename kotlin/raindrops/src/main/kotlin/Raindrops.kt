object Raindrops {

    fun convert(n: Int): String {
        return mapOf(3 to "Pling", 5 to "Plang", 7 to "Plong")
            .filter { n % it.key == 0 }
            .map { it.value }
            .joinToString("")
            .ifEmpty { n.toString() }
    }
}
