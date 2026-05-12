public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        var sum = 0;
        var count = 0;

        foreach (var ch in number)
        {
            if (ch == '-') continue;

            count++;

            int value;

            if (char.IsDigit(ch))
            {
                value = ch - '0';
            }
            else if (ch == 'X' && count == 10)
            {
                value = 10;
            }
            else
            {
                return false;
            }

            sum += value * (11 - count);
        }

        return count == 10 && sum % 11 == 0;
    }
}