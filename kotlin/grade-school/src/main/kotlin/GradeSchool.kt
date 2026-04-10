import java.util.SortedSet

class School {

    val groups = sortedMapOf<Int, SortedSet<String>>()

    fun add(student: String, grade: Int) {
        groups.getOrPut(grade) { sortedSetOf() }.add(student)
    }

    fun grade(grade: Int): List<String> {
        return groups[grade]?.toList() ?: emptyList()
    }

    fun roster(): List<String> {
        return buildList {
            for (students in groups.values) {
                addAll(students)
            }
        }
    }
}
