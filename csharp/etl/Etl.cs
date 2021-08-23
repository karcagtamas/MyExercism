using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var result = new Dictionary<string, int>();
        foreach (var (key, value) in old)
        {
            foreach (var t in value)
            {
                result.Add(t.ToLower(), key);
            }
        }

        return result;
    }
}