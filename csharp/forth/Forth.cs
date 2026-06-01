using System.Text.RegularExpressions;

public static class Forth
{
    private static List<int> stack = [];
    private static Dictionary<string, List<string>> definitions = [];

    public static string Evaluate(string[] instructions)
    {
        stack = [];
        definitions = [];

        var tokens = instructions
            .SelectMany(line => Regex.Split(line.ToLower(), "\\s+"))
            .Where(e => !string.IsNullOrWhiteSpace(e))
            .ToList();

        Process(tokens);

        return string.Join(' ', stack);
    }

    private static void Process(List<string> tokens)
    {
        var i = 0;

        while (i < tokens.Count)
        {
            var token = tokens[i];
            switch (token)
            {
                case ":":
                    var name = i + 1 < tokens.Count ? tokens[i + 1] : throw new ArgumentException($"Invalid token {token}");

                    if (int.TryParse(name, out _))
                    {
                        throw new InvalidOperationException("Illegal operation");
                    }

                    List<string> body = [];

                    i += 2;

                    while (i < tokens.Count && tokens[i] != ";")
                    {
                        body.Add(tokens[i]);
                        i++;
                    }

                    if (i >= tokens.Count) throw new ArgumentException($"Invalid token {token}");

                    definitions[name] = Expand(body);
                    break;
                default:
                    Execute(token);
                    break;
            }

            i++;
        }
    }

    private static void Execute(string token)
    {
        if (int.TryParse(token, out var n))
        {
            stack.Add(n);
            return;
        }

        if (definitions.TryGetValue(token, out var value))
        {
            Process(value);
            return;
        }

        if (token == "+")
        {
            var (a, b) = Pop2();
            stack.Add(a + b);
            return;
        }

        if (token == "-")
        {
            var (a, b) = Pop2();
            stack.Add(a - b);
            return;
        }

        if (token == "*")
        {
            var (a, b) = Pop2();
            stack.Add(a * b);
            return;
        }

        if (token == "/")
        {
            var (a, b) = Pop2();
            if (b == 0) throw new DivideByZeroException();
            stack.Add(a / b);
            return;
        }

        if (token == "dup")
        {
            if (stack.Count == 0) throw new InvalidOperationException("Empty stack");
            stack.Add(stack[^1]);
            return;
        }

        if (token == "drop")
        {
            if (stack.Count == 0) throw new InvalidOperationException("Empty stack");
            stack.RemoveAt(stack.Count - 1);
            return;
        }

        if (token == "swap")
        {
            if (stack.Count == 0) throw new InvalidOperationException("Empty stack");
            if (stack.Count < 2) throw new InvalidOperationException("Only one value on the stack");

            var (a, b) = Pop2();
            stack.Add(b);
            stack.Add(a);

            return;
        }

        if (token == "over")
        {
            if (stack.Count == 0) throw new InvalidOperationException("Empty stack");
            if (stack.Count < 2) throw new InvalidOperationException("Only one value on the stack");

            stack.Add(stack[^2]);

            return;
        }

        throw new InvalidOperationException("Undefined operation");
    }

    private static (int, int) Pop2()
    {
        if (stack.Count <= 0) throw new InvalidOperationException("Empty stack");
        if (stack.Count < 2) throw new InvalidOperationException("Only one value on the stack");

        var b = stack[^1];
        var a = stack[^2];

        stack.RemoveAt(stack.Count - 1);
        stack.RemoveAt(stack.Count - 1);

        return (a, b);
    }

    private static List<string> Expand(List<string> tokens)
    {
        var result = new List<string>();

        foreach (var token in tokens)
        {
            if (definitions.TryGetValue(token, out var value))
            {
                result.AddRange(value);
            }
            else
            {
                result.Add(token);
            }
        }

        return result;
    }
}