class KindergartenGarden(private val diagram: String) {

    private val rows = diagram.split("\n")

    private val students = listOf(
        "Alice", "Bob", "Charlie", "David",
        "Eve", "Fred", "Ginny", "Harriet",
        "Ileana", "Joseph", "Kincaid", "Larry"
    )

    fun getPlantsOfStudent(student: String): List<String> {
        val i = students.indexOf(student)
        require(i != -1) { "Unknown student" }

        val start = i * 2

        return listOf(
            plant(rows[0][start]),
            plant(rows[0][start + 1]),
            plant(rows[1][start]),
            plant(rows[1][start + 1]),
        )
    }

    private fun plant(ch: Char): String = when (ch) {
        'G' -> "grass"
        'C' -> "clover"
        'R' -> "radishes"
        'V' -> "violets"
        else -> error("Unexpected character: $ch")
    }
}
