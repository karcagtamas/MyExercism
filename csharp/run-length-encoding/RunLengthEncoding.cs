using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var res = new StringBuilder(input.Length);

        var latest = input[0];
        var count = 1;

        for (var i = 1; i < input.Length; i++)
        {
            if (input[i] == latest)
            {
                count++;
            }
            else
            {
                if (count > 1)
                {
                    res.Append(count);
                }

                res.Append(latest);
                latest = input[i];
                count = 1;
            }
        }

        if (count > 1) res.Append(count);

        res.Append(latest);

        return res.ToString();
    }

    public static string Decode(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var res = new StringBuilder();
        var count = 0;

        foreach (var c in input)
        {
            if (char.IsDigit(c))
            {
                count = count * 10 + (c - '0');
            }
            else
            {
                var repeat = count == 0 ? 1 : count;
                for (var i = 0; i < repeat; i++)
                {
                    res.Append(c);
                }
                count = 0;
            }
        }

        return res.ToString();
    }
}
