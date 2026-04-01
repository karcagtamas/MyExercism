class PhoneNumber(private val original: String) {
    companion object {
        val COUNTRY_CODE = "1";
    }

    val number: String?

    init {
        var digits = original.filter { it.isDigit() }

        if (digits.length > 10) {
            val countryCode = digits.substring(0, digits.length - 10)
            digits = digits.takeLast(10)

            if (countryCode != COUNTRY_CODE) {
                throw IllegalArgumentException("Invalid country code: $countryCode")
            }
        } else {
            if (digits.length != 10) {
                throw IllegalArgumentException()
            }
        }

        val areaCode = digits.take(3)
        if (areaCode.startsWith("0") || areaCode.startsWith("1")) {
            throw IllegalArgumentException()
        }

        val exchangeCode = digits.takeLast(7)
        if (exchangeCode.startsWith("0") || exchangeCode.startsWith("1")) {
            throw IllegalArgumentException()
        }

        number = digits
    }
}
