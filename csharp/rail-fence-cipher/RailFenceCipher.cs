using System.Text;

public class RailFenceCipher(int rails)
{
    private readonly int rails = rails;

    public string Encode(string input)
    {
        if (rails == 0) return input;

        var rows = new string[rails];

        var rail = 0;
        var direction = 1;

        foreach (var c in input)
        {
            rows[rail] += c;

            if (rail == 0)
            {
                direction = 1;
            }
            else if (rail == rails - 1)
            {
                direction = -1;
            }

            rail += direction;
        }

        return string.Join("", rows);
    }

    public string Decode(string input)
    {
        if (rails == 1) return input;

        var pattern = new int[input.Length];
        var rail = 0;
        var direction = 1;

        for (var i = 0; i < input.Length; i++)
        {
            pattern[i] = rail;

            if (rail == 0)
            {
                direction = 1;
            }
            else if (rail == rails - 1)
            {
                direction = -1;
            }

            rail += direction;
        }

        var counts = new int[rails];

        foreach (var r in pattern)
        {
            counts[r]++;
        }

        var railChars = new char[rails][];

        for (var i = 0; i < rails; i++)
        {
            railChars[i] = new char[counts[i]];
        }

        var index = 0;
        for (var r = 0; r < rails; r++)
        {
            for (var i = 0; i < railChars[r].Length; i++)
            {
                railChars[r][i] = input[index++];
            }
        }

        var railIndicies = new int[rails];
        var builder = new StringBuilder();

        foreach (var r in pattern)
        {
            builder.Append(railChars[r][railIndicies[r]++]);
        }

        return builder.ToString();
    }
}