public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        var counts = new int[7];
        var sum = 0;

        foreach (var d in dice)
        {
            counts[d]++;
            sum += d;
        }

        return category switch
        {
            YachtCategory.Yacht => counts.Any(x => x == 5) ? 50 : 0,
            YachtCategory.Ones => counts[1],
            YachtCategory.Twos => counts[2] * 2,
            YachtCategory.Threes => counts[3] * 3,
            YachtCategory.Fours => counts[4] * 4,
            YachtCategory.Fives => counts[5] * 5,
            YachtCategory.Sixes => counts[6] * 6,
            YachtCategory.FullHouse => ContainsFullHouse(counts) ? sum : 0,
            YachtCategory.FourOfAKind => FourOfAKind(counts),
            YachtCategory.LittleStraight => CountsMatches(counts, 1, 2, 3, 4, 5) ? 30 : 0,
            YachtCategory.BigStraight => CountsMatches(counts, 2, 3, 4, 5, 6) ? 30 : 0,
            YachtCategory.Choice => sum,
            _ => throw new NotImplementedException(),
        };
    }

    private static int FourOfAKind(int[] counts)
    {
        var max = 0;
        for (var i = 6; i >= 1; i--)
        {
            if (counts[i] >= 4 && i * 4 >= max)
            {
                max = i * 4;
            }
        }

        return max;
    }

    private static bool ContainsFullHouse(int[] counts)
    {
        var has3 = false;
        var has2 = false;

        foreach (var c in counts)
        {
            if (c == 3) has3 = true;
            if (c == 2) has2 = true;
        }

        return has3 && has2;
    }

    private static bool CountsMatches(int[] counts, params int[] faces)
    {
        foreach (var f in faces)
        {
            if (counts[f] != 1) return false;
        }

        return true;
    }
}

