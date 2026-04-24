import kotlin.math.max
import kotlin.math.min

data class FlowerFieldBoard(private val inputBoard: List<String>) {

    private val x = inputBoard.size
    private val y = if (x > 0) inputBoard[0].length else 0

    fun withNumbers(): List<String> {
        return inputBoard.mapIndexed { i, row ->
            row.mapIndexed { j, f ->
                when {
                    f == '*' -> f
                    else -> calc(i, j).let { if (it == 0) ' ' else it.digitToChar() }
                }
            }.joinToString("")
        }
    }

    private fun calc(i: Int, j: Int): Int {
        return (max(0, i - 1)..min(x - 1, i + 1)).flatMap { it1 ->
            (max(0, j - 1)..min(y - 1, j + 1)).map { it2 ->
                if (inputBoard[it1][it2] == '*') 1 else 0
            }
        }.sum()
    }
}
