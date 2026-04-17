class CustomSet(vararg values: Int) {

    val items = values.toMutableSet()

    fun isEmpty(): Boolean = items.isEmpty()

    fun isSubset(other: CustomSet): Boolean = items.all { item -> other.contains(item) }

    fun isDisjoint(other: CustomSet): Boolean = items.none { item -> other.contains(item) }

    fun contains(other: Int): Boolean = items.contains(other)

    fun intersection(other: CustomSet): CustomSet = CustomSet(*items.filter { it in other.items }.toIntArray())

    fun add(other: Int) {
        items.add(other)
    }

    override fun equals(other: Any?): Boolean {
        if (other !is CustomSet) return false

        return other.items == this.items
    }

    operator fun plus(other: CustomSet): CustomSet = CustomSet(*(items + other.items).toIntArray())

    operator fun minus(other: CustomSet): CustomSet = CustomSet(*(items - other.items).toIntArray())
}
