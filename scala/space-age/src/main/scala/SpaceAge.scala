object SpaceAge {
    val divider = 60 * 60 * 24 * 365.25
    val mercuryPeriod = 0.2408467
    val venusPeriod = 0.61519726
    val marsPeriod = 1.8808158
    val jupiterPeriod = 11.862615
    val saturnPeriod = 29.447498
    val uranusPeriod = 84.016846
    val neptunePeriod = 164.79132

    def onEarth(seconds: Double): Double = seconds / divider 
    def onMercury(seconds: Double): Double = onEarth(seconds) / mercuryPeriod
    def onVenus(seconds: Double): Double = onEarth(seconds) / venusPeriod
    def onMars(seconds: Double): Double = onEarth(seconds) / marsPeriod
    def onJupiter(seconds: Double): Double = onEarth(seconds) / jupiterPeriod 
    def onSaturn(seconds: Double): Double = onEarth(seconds) / saturnPeriod
    def onUranus(seconds: Double): Double = onEarth(seconds) / uranusPeriod
    def onNeptune(seconds: Double): Double = onEarth(seconds) / neptunePeriod
}