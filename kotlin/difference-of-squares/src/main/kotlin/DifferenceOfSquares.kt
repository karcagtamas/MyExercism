import kotlin.math.pow

class Squares(val n: Int) {

    fun sumOfSquares(): Int {
        return (1..n).sumOf { it * it }
    }

    fun squareOfSum(): Int {
        return (1..n).sum().toDouble().pow(2).toInt()
    }

    fun difference(): Int {
        return squareOfSum() - sumOfSquares()
    }
}
