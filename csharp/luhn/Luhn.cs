public static class Luhn
{
    public static bool IsValid(string number)
    {
        var sum = 0;
        var count = 0;
        var dbl = false;

        for (var i = number.Length - 1; i >= 0; i--)
        {
            var ch = number[i];

            if (ch == ' ') continue;
            if (!char.IsDigit(ch)) return false;

            var digit = ch - '0';

            if (dbl)
            {
                digit *= 2;
                if (digit > 9) digit -= 9;
            }

            sum += digit;
            dbl = !dbl;
            count++;
        }

        return count > 1 && sum % 10 == 0;
    }
}