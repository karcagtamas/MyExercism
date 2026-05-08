public static class KillerSudokuHelper
{
    public static IEnumerable<int[]> Combinations(int sum, int size, int[] exclude)
    {
        List<int[]> result = [];
        var excluded = exclude.ToHashSet();

        Generate(
            start: 1,
            remainingSum: sum,
            remainingSize: size,
            current: [],
            excluded: excluded,
            result: result
        );

        return result;
    }

    private static void Generate(int start, int remainingSum, int remainingSize, List<int> current, HashSet<int> excluded, List<int[]> result)
    {
        if (remainingSize == 0)
        {
            if (remainingSum == 0)
            {
                result.Add([.. current]);
            }

            return;
        }

        for (var digit = start; digit <= 9; digit++)
        {
            if (excluded.Contains(digit))
            {
                continue;
            }

            if (digit > remainingSum)
            {
                break;
            }

            current.Add(digit);

            Generate(
                start: digit + 1,
                remainingSum: remainingSum - digit,
                remainingSize: remainingSize - 1,
                current: current,
                excluded: excluded,
                result: result
            );

            current.RemoveAt(current.Count - 1);
        }
    }
}
