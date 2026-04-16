import kotlin.math.sqrt

object Sieve {

    fun primesUpTo(upperBound: Int): List<Int> {
        return (2..upperBound).filter {
            if (it == 2) return@filter true
            if (it % 2 == 0) return@filter false

            for (x in 3..(sqrt(it.toDouble()).toInt())) {
                if (it % x == 0) return@filter false
            }

            true
        }
    }
}
