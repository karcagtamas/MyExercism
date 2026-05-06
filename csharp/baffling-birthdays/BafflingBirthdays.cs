public static class BafflingBirthdays
{
    public static DateOnly[] RandomBirthdates(int numberOfBirthdays)
    {
        var rnd = new Random();
        List<DateOnly> birthdays = [];

        for (var i = 0; i < numberOfBirthdays; i++)
        {
            int year;

            do
            {
                year = rnd.Next(1, 10000);
            }while(DateTime.IsLeapYear(year));

            birthdays.Add(new DateOnly(year, 1, 1).AddDays(rnd.Next(365)));
        }

        return [.. birthdays];
    }

    public static bool SharedBirthday(DateOnly[] birthdays)
    {
        for (var i = 0; i < birthdays.Length - 1; i++)
        {
            for (var j = i + 1; j < birthdays.Length; j++)
            {
                if (birthdays[i].Month == birthdays[j].Month && birthdays[i].Day == birthdays[j].Day)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static double EstimatedProbabilityOfSharedBirthday(int numberOfBirthdays)
    {
        if (numberOfBirthdays <= 1) return 0.0;

        if (numberOfBirthdays > 365) return 100.0;

        var prob = 1.0;

        for (var i = 0; i < numberOfBirthdays; i++)
        {
            prob *= (365.0 - i) / 365.0;
        }

        return (1.0 - prob) * 100.0;
    }
}
