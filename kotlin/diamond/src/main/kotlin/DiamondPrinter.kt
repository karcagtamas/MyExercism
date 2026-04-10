import kotlin.math.abs

class DiamondPrinter {

    fun printToList(size: Char): List<String> {
        val side = size - 'A' + 1

        val rows = side * 2 - 1
        val columns = side * 2 - 1

        return buildList {
            repeat(rows) { i ->
                val d = minOf(i, rows - 1 - i)
                val c = (d + 'A'.code).toChar()

                add(
                    buildString {
                        repeat(columns) { j ->
                            when (abs(j - columns / 2)) {
                                d -> append(c)
                                else -> append(" ")
                            }
                        }
                    }
                )
            }
        }
    }
}
