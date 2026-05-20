public static class Wordy
{
    public static int Answer(string question)
    {
        if (!question.StartsWith("What is ") || !question.EndsWith('?'))
        {
            throw new ArgumentException("Unknown operation");
        }

        var tokens = question["What is ".Length..^1].Split(' ');

        if (tokens.Length == 0)
        {
            throw new ArgumentException("Syntax error");
        }

        var index = 0;

        var result = int.TryParse(tokens[index++], out int res)
            ? res
            : throw new ArgumentException("Syntax error");

        while (index < tokens.Length)
        {
            var token = tokens[index];
            var operation = "";

            if (token == "plus")
            {
                index++;
                operation = "+";
            }
            else if (token == "minus")
            {
                index++;
                operation = "-";
            }
            else if (token == "multiplied" && index + 1 < tokens.Length && tokens[index + 1] == "by")
            {
                index += 2;
                operation = "*";
            }
            else if (token == "divided" && index + 1 < tokens.Length && tokens[index + 1] == "by")
            {
                index += 2;
                operation = "/";
            }
            else if (token == "raised" && index + 2 < tokens.Length && tokens[index + 1] == "to" && tokens[index + 2] == "the")
            {
                index += 3;
                operation = "^";
            }
            else
            {
                throw new ArgumentException("Unknown operation");
            }

            int number;

            if (operation == "^")
            {
                token = index < tokens.Length
                    ? tokens[index++]
                    : throw new ArgumentException("Syntax error");

                var exponent = new string(
                    [.. token.TakeWhile(char.IsDigit)]);

                if (string.IsNullOrEmpty(exponent))
                    throw new ArgumentException("Syntax error");

                if (index >= tokens.Length || tokens[index++] != "power")
                    throw new ArgumentException("Syntax error");

                number = int.Parse(exponent);
            }
            else
            {
                if (index >= tokens.Length || !int.TryParse(tokens[index++], out number))
                {
                    throw new ArgumentException("Syntax error");
                }
            }

            result = operation switch
            {
                "+" => result + number,
                "-" => result - number,
                "*" => result * number,
                "/" => result / number,
                "^" => result = (int)Math.Pow(result, number),
                _ => throw new ArgumentException("Impossible")
            };
        }

        return result;
    }
}