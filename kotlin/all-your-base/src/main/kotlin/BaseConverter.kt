import kotlin.math.max
import kotlin.math.pow

class BaseConverter(base: Int, digits: IntArray) {

    private val value: Int

    init {
        require(base >= 2) { "Bases must be at least 2." }
        require(digits.isNotEmpty()) { "You must supply at least one digit." }
        require(digits.all { it >= 0 }) { "Digits may not be negative." }
        require(digits.all { it < base }) { "All digits must be strictly less than the base." }
        require(digits.size == 1 || digits[0] != 0) { "Digits may not contain leading zeros." }
        var x = 0

        for (i in digits.indices) {
            val index = digits.size - i - 1

            x += (digits[index] * base.toDouble().pow(i)).toInt()
        }

        value = x
    }

    fun convertToBase(newBase: Int): IntArray {
        require(newBase >= 2) { "Bases must be at least 2." }
        val result = IntArray(getNewSize(newBase))

        var v = value

        for (i in result.indices) {
            val index = result.size - i - 1
            val el = newBase.toDouble().pow(index).toInt()

            result[i] = v / el
            v %= el
        }

        return result
    }

    private fun getNewSize(newBase: Int): Int {
        var x = 0
        var v = 1

        while (v <= value) {
            x++
            v *= newBase
        }

        return max(x, 1)
    }
}
