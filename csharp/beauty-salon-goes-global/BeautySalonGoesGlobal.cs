using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var appointment = DateTime.Parse(appointmentDateDescription);
        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneId(location));

        return TimeZoneInfo.ConvertTimeToUtc(appointment, timeZoneInfo);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddHours(-1).AddMinutes(-45),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => throw new ArgumentException(),
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var zone = TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneId(location));

        var now = zone.IsDaylightSavingTime(dt);
        var weekAgo = zone.IsDaylightSavingTime(dt.AddDays(-7));

        return now != weekAgo;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var culture = location switch
        {
            Location.NewYork => new CultureInfo("en-US"),
            Location.London => new CultureInfo("en-GB"),
            Location.Paris => new CultureInfo("fr-FR"),
            _ => CultureInfo.InvariantCulture
        };

        return DateTime.TryParse(dtStr, culture, DateTimeStyles.None, out var result)
            ? result
            : DateTime.MinValue;
    }

    private static string GetTimeZoneId(Location location)
    {
        var windows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        return location switch
        {
            Location.NewYork => windows
                ? "Eastern Standard Time"
                : "America/New_York",

            Location.London => windows
                ? "GMT Standard Time"
                : "Europe/London",

            Location.Paris => windows
                ? "W. Europe Standard Time"
                : "Europe/Paris",

            _ => throw new ArgumentOutOfRangeException(nameof(location))
        };
    }
}
