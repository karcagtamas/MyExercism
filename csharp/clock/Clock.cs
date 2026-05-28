public class Clock
{
    private static readonly int DAY_MINUTES = 24 * 60;

    private int hours;
    private int minutes;

    public Clock(int hours, int minutes)
    {
        this.hours = hours;
        this.minutes = minutes;
        Normalize();
    }

    public Clock Add(int minutesToAdd)
    {
        minutes += minutesToAdd;
        Normalize();
        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        minutes -= minutesToSubtract;
        Normalize();
        return this;
    }

    private void Normalize()
    {
        var mins = hours * 60 + minutes;
        var normalized = ((mins % DAY_MINUTES) + DAY_MINUTES) % DAY_MINUTES;
        hours = normalized / 60;
        minutes = normalized % 60;
    }

    public override bool Equals(object? obj) => obj is Clock other && hours == other.hours && minutes == other.minutes;

    public override int GetHashCode() => HashCode.Combine(hours, minutes);

    public override string ToString() => $"{hours:00}:{minutes:00}";
}
