import kotlin.math.abs

class DiamondPrinter {

    fun printToList(size: Char): List<String> {
        val side = size - 'A' + 1
        val rows = side * 2 - 1

        return buildList {
            repeat(rows) { i ->
                val d = minOf(i, rows - 1 - i)
                val c = (d + 'A'.code).toChar()

                val outerSpaces = side - d - 1

                add(
                    buildString {
                        repeat(outerSpaces) { append(" ") }
                        append(c)

                        if (d > 0) {
                            repeat(2 * d - 1) { append(" ") }
                            append(c)
                        }

                        repeat(outerSpaces) { append(" ") }
                    }
                )
            }
        }
    }
}
