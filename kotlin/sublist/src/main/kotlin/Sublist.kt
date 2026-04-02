enum class Relationship {

    EQUAL, SUBLIST, SUPERLIST, UNEQUAL


}

fun <T> List<T>.relationshipTo(other: List<T>): Relationship {
    if (this == other) {
        return Relationship.EQUAL
    }

    if (this.isEmpty()) {
        return Relationship.SUBLIST
    }

    if (other.isEmpty()) {
        return Relationship.SUPERLIST
    }

    return when {
        this.containsSublist(other) -> Relationship.SUPERLIST
        other.containsSublist(this) -> Relationship.SUBLIST
        else -> Relationship.UNEQUAL
    }
}

private fun <T> List<T>.containsSublist(sublist: List<T>): Boolean {
    val n = this.size
    val m = sublist.size

    if (m > n) return false

    outer@ for (i in 0..n - m) {
        for (j in 0 until m) {
            if (this[i + j] != sublist[j]) {
                continue@outer
            }
        }
        return true
    }

    return false
}
