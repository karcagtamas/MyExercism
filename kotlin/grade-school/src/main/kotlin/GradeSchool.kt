import java.util.SortedSet

class School {

    val groups = sortedMapOf<Int, SortedSet<String>>()

    fun add(student: String, grade: Int) {
        if (groups.containsKey(grade)) {
            groups[grade]?.add(student)
        } else {
            groups[grade] = sortedSetOf(student)
        }
    }

    fun grade(grade: Int): List<String> {
        return groups[grade]?.toList() ?: emptyList()
    }

    fun roster(): List<String> {
        return groups.flatMap { it.value.toList() }
    }
}
