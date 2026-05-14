public enum Color { Red, Green, Ivory, Yellow, Blue }
public enum Nationality { Englishman, Spaniard, Ukrainian, Japanese, Norwegian }
public enum Pet { Dog, Snails, Fox, Horse, Zebra }
public enum Drink { Coffee, Tea, Milk, OrangeJuice, Water }
public enum Smoke { OldGold, Kools, Chesterfields, LuckyStrike, Parliaments }

public static class ZebraPuzzle
{
    private static Nationality _waterOwner;
    private static Nationality _zebraOwner;
    private static bool _solved;

    public static Nationality DrinksWater()
    {
        Solve();
        return _waterOwner;
    }

    public static Nationality OwnsZebra()
    {
        Solve();
        return _zebraOwner;
    }

    private static void Solve()
    {
        if (_solved)
        {
            return;
        }

        var houses = new[] { 0, 1, 2, 3, 4 };

        foreach (var colors in Permute(houses))
        {
            var red = colors[(int)Color.Red];
            var green = colors[(int)Color.Green];
            var ivory = colors[(int)Color.Ivory];
            var yellow = colors[(int)Color.Yellow];
            var blue = colors[(int)Color.Blue];

            if (green != ivory + 1) continue;

            foreach (var nationals in Permute(houses))
            {
                var english = nationals[(int)Nationality.Englishman];
                var spaniard = nationals[(int)Nationality.Spaniard];
                var ukrainian = nationals[(int)Nationality.Ukrainian];
                var japanese = nationals[(int)Nationality.Japanese];
                var norwegian = nationals[(int)Nationality.Norwegian];

                if (norwegian != 0) continue;

                if (english != red) continue;

                if (Math.Abs(norwegian - blue) != 1) continue;

                foreach (var drinks in Permute(houses))
                {
                    var coffee = drinks[(int)Drink.Coffee];
                    var tea = drinks[(int)Drink.Tea];
                    var milk = drinks[(int)Drink.Milk];
                    var orange = drinks[(int)Drink.OrangeJuice];
                    var water = drinks[(int)Drink.Water];

                    if (milk != 2) continue;

                    if (coffee != green) continue;

                    if (tea != ukrainian) continue;

                    foreach (var smokes in Permute(houses))
                    {
                        var oldGold = smokes[(int)Smoke.OldGold];
                        var kools = smokes[(int)Smoke.Kools];
                        var chester = smokes[(int)Smoke.Chesterfields];
                        var lucky = smokes[(int)Smoke.LuckyStrike];
                        var parliaments = smokes[(int)Smoke.Parliaments];

                        if (yellow != kools) continue;

                        if (lucky != orange) continue;

                        if (japanese != parliaments) continue;

                        foreach (var pets in Permute(houses))
                        {
                            var dog = pets[(int)Pet.Dog];
                            var snails = pets[(int)Pet.Snails];
                            var fox = pets[(int)Pet.Fox];
                            var horse = pets[(int)Pet.Horse];
                            var zebra = pets[(int)Pet.Zebra];

                            if (spaniard != dog) continue;

                            if (snails != oldGold) continue;

                            if (Math.Abs(fox - chester) != 1) continue;
                            
                            if (Math.Abs(horse - kools) != 1) continue;

                            _waterOwner = FindOwner(water, nationals);
                            _zebraOwner = FindOwner(zebra, nationals);

                            _solved = true;

                            return;
                        }
                    }
                }
            }
        }

        throw new Exception("No solution found");
    }

    private static Nationality FindOwner(int house, int[] map) => (Nationality)Array.IndexOf(map, house);

    private static IEnumerable<int[]> Permute(int[] values)
    {
        if (values.Length == 1)
        {
            yield return values;
            yield break;
        }

        for (int i = 0; i < values.Length; i++)
        {
            var current = values[i];
            var remaining = values.Where((_, idx) => idx != i).ToArray();

            foreach (var p in Permute(remaining))
            {
                yield return new[] { current }.Concat(p).ToArray();
            }
        }
    }
}