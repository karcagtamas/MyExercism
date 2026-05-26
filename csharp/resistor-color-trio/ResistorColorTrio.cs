public static class ResistorColorTrio
{
    private static readonly string[] COLORS = ["black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"];
    private static readonly string[] UNITS = ["ohms", "kiloohms", "megaohms", "gigaohms", "teraohms", "petaohms", "exaohms"];

    public static string Label(string[] colors)
    {
        var values = colors.Select(c => Array.IndexOf(COLORS, c)).Take(3).ToList();

        var number = (int)values.Take(2)
            .Reverse()
            .Select((i, index) => i * Math.Pow(10.0, index))
            .Sum();
        var zeros = values.Last();

        if (number % 10 == 0)
        {
            number /= 10;
            zeros++;
        }

        var unit = UNITS[zeros / 3];
        number *= (int)Math.Pow(10, zeros % 3);

        return $"{number} {unit}";
    }
}
