object Series {

    fun slices(n: Int, s: String): List<List<Int>> {
        require(n <= s.length)
        require(n >= 1)

        val result = ArrayList<List<Int>>(s.length - n + 1)

        for (i in 0..s.length - n) {
            val slice = IntArray(n)

            for (j in 0 until n) {
                slice[j] = s[i + j].digitToInt()
            }
            result.add(slice.toList())
        }

        return result
    }
}
