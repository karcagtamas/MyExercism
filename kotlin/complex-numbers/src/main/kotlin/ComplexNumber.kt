import kotlin.math.cos
import kotlin.math.exp
import kotlin.math.sin
import kotlin.math.sqrt

data class ComplexNumber(val real: Double = 0.0, val imag: Double = 0.0) {

    val abs: Double
        get() = sqrt(real * real + imag * imag)

    operator fun plus(that: ComplexNumber): ComplexNumber =
        ComplexNumber(real + that.real, imag + that.imag)

    operator fun minus(that: ComplexNumber): ComplexNumber =
        ComplexNumber(real - that.real, imag - that.imag)

    operator fun times(that: ComplexNumber): ComplexNumber =
        ComplexNumber(real * that.real - imag * that.imag, imag * that.real + real * that.imag)

    operator fun div(that: ComplexNumber): ComplexNumber {
        val denominator = that.real * that.real + that.imag * that.imag

        return ComplexNumber(
            (real * that.real + imag * that.imag) / denominator,
            (imag * that.real - real * that.imag) / denominator,
        )
    }

    fun conjugate(): ComplexNumber = ComplexNumber(real, -imag)
}

fun exponential(c: ComplexNumber): ComplexNumber {
    val expReal = exp(c.real)

    return ComplexNumber(
        expReal * cos(c.imag),
        expReal * sin(c.imag),
    )
}
