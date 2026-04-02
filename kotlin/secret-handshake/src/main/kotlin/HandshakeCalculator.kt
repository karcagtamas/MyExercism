import kotlin.math.pow

object HandshakeCalculator {
    fun calculateHandshake(number: Int): List<Signal> {
        val results = Signal.values()
            .filter { number and (2.0.pow(it.ordinal).toInt()) != 0 }

        return if ((number and 16) != 0) results.reversed() else results
    }
}
