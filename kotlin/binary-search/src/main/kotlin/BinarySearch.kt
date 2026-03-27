object BinarySearch {
    fun search(list: List<Int>, item: Int): Int {
        if (list.isEmpty()) {
            throw NoSuchElementException()
        }

        val n = list.size / 2

        if (item < list[n]) {
            return search(list.subList(0, n), item)
        } else if (item > list[n]) {
            return search(list.subList(n + 1, list.size), item) + n + 1
        }

        return n
    }
}
