public static class SecretHandshake
{
    private static readonly string[] signals = [
        "wink",
        "double blink",
        "close your eyes",
        "jump",
    ];

    public static string[] Commands(int commandValue)
    {
        var results = new List<string>();

        for (var i = 0; i < signals.Length; i++)
        {
            if ((commandValue & ((int)Math.Pow(2, i))) != 0)
            {
                results.Add(signals[i]);
            }
        }

        if ((commandValue & 16) != 0)
        {
            results.Reverse();
        }

        return [.. results];
    }
}
