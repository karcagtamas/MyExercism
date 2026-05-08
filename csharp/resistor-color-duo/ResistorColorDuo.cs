public static class ResistorColorDuo
{
    private static readonly string[] COLORS = [
        "black",
        "brown",
        "red",
        "orange",
        "yellow",
        "green",
        "blue",
        "violet",
        "grey",
        "white"
    ];

    public static int Value(string[] colors) => (int)colors.Take(2)
            .Select(x => COLORS.IndexOf(x))
            .Reverse()
            .Select((x, index) => x * Math.Pow(10.0, index))
            .Sum();
}
