using System;

public class SpaceAge
{
    public int Seconds
    {
        get { return this.seconds; }
    }
    private int seconds;
    private const double divider = 60 * 60 * 24 * 365.25;
    private const double mercuryPeriod = 0.2408467;
    private const double venusPeriod = 0.61519726;
    private const double marsPeriod = 1.8808158;
    private const double jupiterPeriod = 11.862615;
    private const double saturnPeriod = 29.447498;
    private const double uranusPeriod = 84.016846;
    private const double neptunePeriod = 164.79132;

    public SpaceAge(int seconds)
    {
        this.seconds = seconds;
    }

    public double OnEarth()
    {
        return (double)this.Seconds / divider;
    }

    public double OnMercury()
    {
        return this.OnEarth() / mercuryPeriod;
    }

    public double OnVenus()
    {
        return this.OnEarth() / venusPeriod;
    }

    public double OnMars()
    {
        return this.OnEarth() / marsPeriod;
    }

    public double OnJupiter()
    {
        return this.OnEarth() / jupiterPeriod;
    }

    public double OnSaturn()
    {
        return this.OnEarth() / saturnPeriod;
    }

    public double OnUranus()
    {
        return this.OnEarth() / uranusPeriod;
    }

    public double OnNeptune()
    {
        return this.OnEarth() / neptunePeriod;
    }
}