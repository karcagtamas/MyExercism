import kotlin.math.pow

object ArmstrongNumber {

    fun check(input: Int): Boolean {
        return input.toString()
            .map { ch ->
                ch.digitToInt().toDouble().pow(input.toString().length).toInt()
            }
            .sum() == input
    }

}
