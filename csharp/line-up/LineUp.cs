public static class LineUp
{
    public static string Format(string name, int number) => $"{name}, you are the {Format(number)} customer we serve today. Thank you!";

    private static string Format(int number)
    {
        var stringified = number.ToString();
        if (stringified.EndsWith('1') && !stringified.EndsWith("11"))
        {
            return $"{number}st";
        }

        if (stringified.EndsWith('2') && !stringified.EndsWith("12"))
        {
            return $"{number}nd";
        }

        if (stringified.EndsWith('3') && !stringified.EndsWith("13"))
        {
            return $"{number}rd";
        }

        return $"{number}th";
    }
}
