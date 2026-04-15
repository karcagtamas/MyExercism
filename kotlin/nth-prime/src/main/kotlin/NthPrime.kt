import kotlin.math.sqrt

object Prime {

    fun nth(n: Int): Int {
        require(n > 0) { "There is no zeroth prime." }
        var x = 2
        var c = 1

        while (c < n) {
            x++

            if (isPrime(x)) {
                c++
            }
        }

        return x
    }

    private fun isPrime(n: Int): Boolean {
        if (n < 2) return false
        if (n == 2) return true
        if (n % 2 == 0) return false

        for (i in 3..(sqrt(n.toDouble()).toInt()) step 2) {
            if (n % i == 0) {
                return false
            }
        }

        return true
    }
}
