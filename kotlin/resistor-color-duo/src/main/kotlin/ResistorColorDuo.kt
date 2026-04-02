import kotlin.math.pow

object ResistorColorDuo {

    fun value(vararg colors: Color): Int {
        return colors.take(2)
            .map { it.ordinal }
            .reversed()
            .mapIndexed { index, i -> i * 10.0.pow(index) }
            .sum()
            .toInt()
    }
}
