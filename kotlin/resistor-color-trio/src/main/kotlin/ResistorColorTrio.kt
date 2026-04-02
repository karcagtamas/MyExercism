import kotlin.math.pow

object ResistorColorTrio {

    fun text(vararg input: Color): String {
        val values = input.map { c -> c.ordinal }

        var number = values.take(2)
            .reversed()
            .mapIndexed { index, i -> i * 10.0.pow(index) }
            .sum()
            .toInt()
        var zeros = values.last()

        if (number % 10 == 0) {
            number /= 10
            zeros++
        }

        val unit = Unit.values()[zeros / 3]
        number *= 10.0.pow(zeros % 3).toInt()

        return "$number ${unit.toString().lowercase()}"
    }
}
