public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        Stack<char> stack = [];

        var pairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

        foreach (var ch in input)
        {
            if (pairs.ContainsValue(ch))
            {
                stack.Push(ch);
            }
            else if (pairs.ContainsKey(ch))
            {
                if (stack.Count == 0 || stack.Pop() != pairs[ch])
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}
