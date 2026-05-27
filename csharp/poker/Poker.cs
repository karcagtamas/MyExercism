public static class Poker
{
    public static IEnumerable<string> BestHands(IEnumerable<string> hands)
    {
        var scored = hands
            .Select(h => new
            {
                Hand = h,
                Score = Evaluate(h)
            })
            .ToList();

        var bestScore = scored
            .Select(x => x.Score)
            .OrderByDescending(x => x)
            .First();

        return scored
            .Where(x => x.Score.CompareTo(bestScore) == 0)
            .Select(x => x.Hand);
    }

    private static HandRank Evaluate(string hand)
    {
        var cards = hand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var parsed = cards.Select(card =>
        {
            var rank = card[..^1];
            var suit = card[^1];

            return (Rank: ParseRank(rank), Suit: suit);
        }).ToList();

        var values = parsed.Select(p => p.Rank).ToList();
        var suits = parsed.Select(p => p.Suit).ToList();

        values.Sort();

        var flush = suits.Distinct().Count() == 1;
        var straight = IsStraight(values);

        var groups = values
            .GroupBy(v => v)
            .Select(g => g.Count())
            .OrderByDescending(x => x)
            .ToList();

        var category =
            straight && flush
                ? 8
                : groups[0] == 4
                    ? 7
                    : groups[0] == 3 && groups[1] == 2
                        ? 6
                        : flush
                            ? 5
                            : straight
                                ? 4
                                : groups[0] == 3
                                    ? 3
                                    : groups[0] == 2 && groups[1] == 2
                                        ? 2
                                        : groups[0] == 2
                                            ? 1
                                            : 0;

        var isWheelStraight = values.OrderBy(x => x).SequenceEqual([2, 3, 4, 5, 14]);
        var tiebreak = straight && isWheelStraight
            ? [5, 4, 3, 2, 1]
            : values
                .GroupBy(v => v)
                .OrderByDescending(g => g.Count())
                .ThenByDescending(g => g.Key)
                .SelectMany(g => g)
                .ToArray();

        return new HandRank(category, tiebreak);
    }

    private static int ParseRank(string rank) => rank switch
    {
        "2" => 2,
        "3" => 3,
        "4" => 4,
        "5" => 5,
        "6" => 6,
        "7" => 7,
        "8" => 8,
        "9" => 9,
        "10" => 10,
        "T" => 10,
        "J" => 11,
        "Q" => 12,
        "K" => 13,
        "A" => 14,
        _ => throw new ArgumentException("Invalid card")
    };

    private static bool IsStraight(List<int> v)
    {
        var sorted = v.OrderBy(x => x).ToList();


        bool normal = true;
        for (int i = 1; i < sorted.Count; i++)
        {
            if (sorted[i] != sorted[i - 1] + 1)
            {
                normal = false;
                break;
            }
        }

        return normal || sorted.SequenceEqual([2, 3, 4, 5, 14]);
    }

    private readonly record struct HandRank(int Category, int[] Values) : IComparable<HandRank>
    {
        public int CompareTo(HandRank other)
        {
            int c = Category.CompareTo(other.Category);
            if (c != 0) return c;

            for (int i = 0; i < Values.Length; i++)
            {
                int cmp = Values[i].CompareTo(other.Values[i]);
                if (cmp != 0) return cmp;
            }

            return 0;
        }
    }
}