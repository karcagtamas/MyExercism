using System.Collections.Generic;
using System.Linq;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        var result = new Dictionary<char, int>();

        foreach (var text in texts)
        {
            foreach (var c in text.ToLower().Trim().Where(c => c != ',' && (c < '0' || c > '9')))
            {
                if (result.ContainsKey(c))
                {
                    result[c]++;
                }
                else
                {
                    result.Add(c, 1);
                }
            }
        }

        return result;
    }
}