using System;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private int Month;
    private int Year;
    public Meetup(int month, int year)
    {
        this.Month = month;
        this.Year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        switch (schedule)
        {
            case Schedule.Teenth:
                return GetTeenthDay(dayOfWeek);
            case Schedule.First:
                return GetFirstDay(dayOfWeek);
            case Schedule.Second:
                return GetFirstDay(dayOfWeek, 2);
            case Schedule.Third:
                return GetFirstDay(dayOfWeek, 3);
            case Schedule.Fourth:
                return GetFirstDay(dayOfWeek, 4);
            case Schedule.Last:
                return GetLastDay(dayOfWeek);
            default:
                return new DateTime();
        }
    }

    private DateTime GetTeenthDay(DayOfWeek dayOfWeek)
    {
        DateTime date = new DateTime(this.Year, this.Month, 13);
        while (!dayOfWeek.Equals(date.DayOfWeek))
        {
            date = new DateTime(this.Year, this.Month, date.Day + 1);
        }
        return date;
    }
    private DateTime GetFirstDay(DayOfWeek dayOfWeek, int count = 1)
    {
        DateTime date = new DateTime(this.Year, this.Month, 1);
        while (count != 0)
        {
            if (date.DayOfWeek.Equals(dayOfWeek))
            {
                count--;
            }
            if (count == 0)
            {
                break;
            }
            date = new DateTime(this.Year, this.Month, date.Day + 1);
        }
        return date;
    }

    private DateTime GetLastDay(DayOfWeek dayOfWeek)
    {
        DateTime date = new DateTime(this.Year, this.Month, DateTime.DaysInMonth(this.Year, this.Month));
        while (!dayOfWeek.Equals(date.DayOfWeek))
        {
            date = new DateTime(this.Year, this.Month, date.Day - 1);
        }
        return date;
    }
}