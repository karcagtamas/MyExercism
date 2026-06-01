public static class Alphametics
{
    public static IDictionary<char, int> Solve(string equation)
    {
        var parts = equation.Split(" == ");

        var addends = parts[0].Split(" + ").ToArray();
        var result = parts[1];

        var letters = equation.Where(char.IsLetter).Distinct().ToArray();

        if (letters.Length > 10) throw new ArgumentException();

        var leadingLetters = addends
            .Append(result)
            .Where(w => w.Length > 1)
            .Select(w => w[0])
            .ToHashSet();

        var assignment = new Dictionary<char, int>();
        var usedDigits = new bool[10];

        if (Search(addends, result, letters, leadingLetters, assignment, usedDigits))
        {
            return assignment;
        }

        throw new ArgumentException("No solution");
    }

    private static bool Search(string[] addends, string result, char[] letters, HashSet<char> leadingLetters, Dictionary<char, int> assignment, bool[] usedDigits)
    {
        if (assignment.Count == letters.Length)
        {
            long sum = addends.Sum(w => WordValue(w, assignment));
            long answer = WordValue(result, assignment);

            return sum == answer;
        }

        char letter = letters[assignment.Count];

        for (int digit = 0; digit <= 9; digit++)
        {
            if (usedDigits[digit]) continue;

            if (digit == 0 && leadingLetters.Contains(letter)) continue;

            assignment[letter] = digit;
            usedDigits[digit] = true;

            if (Search(addends, result, letters, leadingLetters, assignment, usedDigits))
            {
                return true;
            }

            assignment.Remove(letter);
            usedDigits[digit] = false;
        }

        return false;
    }

    private static long WordValue(string word, IReadOnlyDictionary<char, int> map)
    {
        long value = 0;

        foreach (var c in word)
        {
            value = value * 10 + map[c];
        }

        return value;
    }
}