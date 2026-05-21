public class DndCharacter
{
    private static readonly Random rnd = new();
    public int Strength { get; init; }
    public int Dexterity { get; init; }
    public int Constitution { get; init; }
    public int Intelligence { get; init; }
    public int Wisdom { get; init; }
    public int Charisma { get; init; }
    public int Hitpoints { get; init; }

    public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2.0);

    public static int Ability()
    {
        var dice = new List<int>();

        for (var i = 0; i <= 3; i++)
        {
            dice.Add(rnd.Next(1, 7));
        }

        dice.Sort();
        dice.Reverse();

        return dice.Take(3).Sum();
    }

    public static DndCharacter Generate()
    {
        var con = Ability();
        return new()
        {
            Strength = Ability(),
            Dexterity = Ability(),
            Constitution = con,
            Intelligence = Ability(),
            Wisdom = Ability(),
            Charisma = Ability(),
            Hitpoints = 10 + Modifier(con),
        };
    }
}
