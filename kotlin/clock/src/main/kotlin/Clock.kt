class Clock(var h: Int, var m: Int) {

    companion object {
        const val DAY_MINUTES = 24 * 60
    }

    init {
        normalize()
    }


    fun subtract(minutes: Int) {
        m -= minutes
        normalize()
    }

    fun add(minutes: Int) {
        m += minutes
        normalize()
    }

    private fun normalize() {
        val mins = h * 60 + m
        val normalized = ((mins % DAY_MINUTES) + DAY_MINUTES) % DAY_MINUTES
        h = normalized / 60
        m = normalized % 60
    }

    override fun hashCode(): Int {
        var result = h
        result = 31 * result + m
        return result
    }

    override fun equals(other: Any?): Boolean {
        if (other is Clock) {
            return h == other.h && m == other.m
        }

        return false
    }

    override fun toString(): String {
        return "${h.toString().padStart(2, '0')}:${m.toString().padStart(2, '0')}"
    }
}
