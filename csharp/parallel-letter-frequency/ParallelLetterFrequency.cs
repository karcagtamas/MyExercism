using System.Collections.Concurrent;

public static class ParallelLetterFrequency
{
    public static Task<Dictionary<char, int>> Calculate(IEnumerable<string> texts)
    {
        var result = new ConcurrentDictionary<char, int>();

        foreach (var text in texts)
        {
            foreach (var c in text)
            {
                if (!char.IsLetter(c)) continue;

                var lower = char.ToLower(c);

                result.AddOrUpdate(lower, 1, (_, cnt) => cnt + 1);
            }
        }

        return Task.FromResult(result.ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
    }
}