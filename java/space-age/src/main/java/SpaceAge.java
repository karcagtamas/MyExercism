class SpaceAge {

    private final double seconds;

    private static final double divider = 60 * 60 * 24 * 365.25;
    private static final double mercuryPeriod = 0.2408467;
    private static final double venusPeriod = 0.61519726;
    private static final double marsPeriod = 1.8808158;
    private static final double jupiterPeriod = 11.862615;
    private static final double saturnPeriod = 29.447498;
    private static final double uranusPeriod = 84.016846;
    private static final double neptunePeriod = 164.79132;

    SpaceAge(double seconds) {
        this.seconds = seconds;
    }

    double getSeconds() {
        return seconds;
    }

    double onEarth() {
        return this.seconds / divider;
    }

    double onMercury() {
        return onEarth() / mercuryPeriod;
    }

    double onVenus() {
        return onEarth() / venusPeriod;
    }

    double onMars() {
        return onEarth() / marsPeriod;
    }

    double onJupiter() {
        return onEarth() / jupiterPeriod;
    }

    double onSaturn() {
        return onEarth() / saturnPeriod;
    }

    double onUranus() {
        return onEarth() / uranusPeriod;
    }

    double onNeptune() {
        return onEarth() / neptunePeriod;
    }

}
