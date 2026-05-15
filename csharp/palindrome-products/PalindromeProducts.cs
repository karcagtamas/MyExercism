public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor) => Find(minFactor, maxFactor, true);

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor) => Find(minFactor, maxFactor, false);

    private static (int, IEnumerable<(int, int)>) Find(int minFactor, int maxFactor, bool largest)
    {
        if (maxFactor < minFactor)
        {
            throw new ArgumentException("Invalid range");
        }

        var palindromes = new Dictionary<int, List<(int, int)>>();

        for (var i = minFactor; i <= maxFactor; i++)
        {
            for (var j = i; j <= maxFactor; j++)
            {
                var product = i * j;

                if (!IsPalindrome(product))
                {
                    continue;
                }

                if (!palindromes.ContainsKey(product))
                {
                    palindromes[product] = [];
                }

                palindromes[product].Add((i, j));
            }
        }

        if (palindromes.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var value = largest ? palindromes.Keys.Max() : palindromes.Keys.Min();

        return (value, palindromes[value]);
    }

    private static bool IsPalindrome(int number)
    {
        var s = number.ToString();
        return s.SequenceEqual(s.Reverse());
    }
}
