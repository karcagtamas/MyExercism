public static class SwiftScheduling
{
    public static DateTime DeliveryDate(DateTime meetingStart, string description)
    {
        return description switch
        {
            "NOW" => meetingStart.AddHours(2),
            "ASAP" => GetAsap(meetingStart),
            "EOW" => GetEndOfWeek(meetingStart),
            _ when description.EndsWith('M') => GetMonth(meetingStart, description),
            _ when description.StartsWith('Q') => GetQuarter(meetingStart, description),
            _ => throw new ArgumentException()
        };
    }

    private static DateTime GetAsap(DateTime meeting) => meeting.Hour < 13
            ? new DateTime(meeting.Year, meeting.Month, meeting.Day, 17, 0, 0)
            : new DateTime(meeting.Year, meeting.Month, meeting.Day, 13, 0, 0).AddDays(1);

    private static DateTime GetEndOfWeek(DateTime meeting)
    {
        return meeting.DayOfWeek switch
        {
            DayOfWeek.Monday or DayOfWeek.Tuesday or DayOfWeek.Wednesday => NextDay(meeting, DayOfWeek.Friday, 17),
            _ => NextDay(meeting, DayOfWeek.Sunday, 20),
        };
    }

    private static DateTime GetMonth(DateTime meeting, string description)
    {
        int month = int.Parse(description[..^1]);
        int year = meeting.Month < month ? meeting.Year : meeting.Year + 1;

        var date = new DateTime(year, month, 1, 8, 0, 0);

        while (date.DayOfWeek is DayOfWeek.Sunday or DayOfWeek.Saturday)
        {
            date = date.AddDays(1);
        }

        return date;
    }

    private static DateTime GetQuarter(DateTime meeting, string description)
    {
        int quarter = int.Parse(description[1..]);

        int meetingQuarter = ((meeting.Month - 1) / 3) + 1;

        int year = meetingQuarter <= quarter ? meeting.Year : meeting.Year + 1;

        int lastMonth = quarter * 3;

        var date = new DateTime(year, lastMonth, DateTime.DaysInMonth(year, lastMonth), 8, 0, 0);

        while (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
        {
            date = date.AddDays(-1);
        }

        return date;
    }

    private static DateTime NextDay(DateTime current, DayOfWeek target, int hour)
    {
        int days = ((int)target - (int)current.DayOfWeek + 7) % 7;

        return current.Date.AddDays(days).AddHours(hour);
    }
}
