import kotlin.math.sqrt

object Darts {

    fun score(x: Number, y: Number): Int {
        val radius = sqrt(x.toDouble() * x.toDouble() + y.toDouble() * y.toDouble())

        return if (radius > 10) {
            0
        } else if (radius > 5) {
            1
        } else if (radius > 1) {
            5
        } else {
            10
        }
    }
}
