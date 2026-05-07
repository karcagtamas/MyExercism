public static class Bob
{
    public static string Response(string statement)
    {
        if (statement.Trim() == "")
        {
            return "Fine. Be that way!";
        }

        var isYelling = statement.All(c => !char.IsLetter(c) || char.IsUpper(c)) && statement.Any(char.IsLetter);
        var isQuestion = statement.TrimEnd()[^1] == '?';

        if (isYelling && isQuestion)
        {
            return "Calm down, I know what I'm doing!";
        }

        if (isQuestion)
        {
            return "Sure.";
        }

        if (isYelling)
        {
            return "Whoa, chill out!";
        }

        return "Whatever.";
    }
}