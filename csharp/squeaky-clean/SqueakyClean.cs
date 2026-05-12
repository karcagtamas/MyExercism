using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var result = new StringBuilder();

        var upperNext = false;

        foreach (var c in identifier)
        {
            if (c == ' ')
            {
                result.Append('_');
            }
            else if (char.IsControl(c))
            {
                result.Append("CTRL");
            }
            else if (c == '-')
            {
                upperNext = true;
            }
            else if (c >= 'α' && c <= 'ω')
            {
                continue;
            }
            else if (char.IsLetter(c))
            {
                result.Append(upperNext ? char.ToUpper(c) : c);
                upperNext = false;
            }
        }

        return result.ToString();
    }
}
