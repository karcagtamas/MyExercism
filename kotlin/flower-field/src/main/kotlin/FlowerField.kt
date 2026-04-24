import kotlin.math.max
import kotlin.math.min

data class FlowerFieldBoard(private val inputBoard: List<String>) {

    private val x = inputBoard.size
    private val y = if (x > 0) inputBoard[0].length else 0

    fun withNumbers(): List<String> {
        return List(x) { i ->
            buildString {
                for (j in 0 until y) {
                    if (inputBoard[i][j] == '*') {
                        append('*')
                    } else {
                        val count = calc(i, j)

                        append(if (count == 0) ' ' else '0' + count)
                    }
                }
            }
        }
    }

    private fun calc(i: Int, j: Int): Int {
        var count = 0

        (max(0, i - 1)..min(x - 1, i + 1)).forEach { r ->
            (max(0, j - 1)..min(y - 1, j + 1)).forEach { c ->
                if (inputBoard[r][c] == '*') {
                    count++
                }
            }
        }

        return count
    }
}
