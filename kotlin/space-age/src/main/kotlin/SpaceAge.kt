class SpaceAge(private val seconds: Int) {

    companion object {
        const val YEAR_ON_EARTH_IN_SECS = 31_557_600

        const val MERCURY_ORBITAL_PERIOD = 0.2408467
        const val VENUS_ORBITAL_PERIOD = 0.61519726
        const val MARS_ORBITAL_PERIOD = 1.8808158
        const val JUPITER_ORBITAL_PERIOD = 11.862615
        const val SATURN_ORBITAL_PERIOD = 29.447498
        const val URANUS_ORBITAL_PERIOD = 84.016846
        const val NEPTUNE_ORBITAL_PERIOD = 164.79132
    }

    fun onEarth(): Double = seconds / YEAR_ON_EARTH_IN_SECS.toDouble()
    fun onMercury(): Double = onEarth() / MERCURY_ORBITAL_PERIOD
    fun onVenus(): Double = onEarth() / VENUS_ORBITAL_PERIOD
    fun onMars(): Double = onEarth() / MARS_ORBITAL_PERIOD
    fun onJupiter(): Double = onEarth() / JUPITER_ORBITAL_PERIOD
    fun onSaturn(): Double = onEarth() / SATURN_ORBITAL_PERIOD
    fun onUranus(): Double = onEarth() / URANUS_ORBITAL_PERIOD
    fun onNeptune(): Double = onEarth() / NEPTUNE_ORBITAL_PERIOD
}
