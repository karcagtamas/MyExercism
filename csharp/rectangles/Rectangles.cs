public static class Rectangles
{
    public static int Count(string[] rows)
    {
        if (rows.Length == 0)
        {
            return 0;
        }

        var r = rows.Length;
        var c = rows[0].Length;
        var count = 0;

        for (var r1 = 0; r1 < r; r1++)
        {
            for (var r2 = r1 + 1; r2 < r; r2++)
            {
                for (var c1 = 0; c1 < c; c1++)
                {
                    for (var c2 = c1 + 1; c2 < c; c2++)
                    {
                        if (IsRectangle(rows, r1, r2, c1, c2))
                        {
                            count++;
                        }
                    }
                }
            }
        }

        return count;
    }

    private static bool IsRectangle(string[] rows, int r1, int r2, int c1, int c2)
    {
        if (rows[r1][c1] != '+' ||
            rows[r1][c2] != '+' ||
            rows[r2][c1] != '+' ||
            rows[r2][c2] != '+')
        {
            return false;
        }

        for (var c = c1 + 1; c < c2; c++)
        {
            if (rows[r1][c] != '-' && rows[r1][c] != '+')
                return false;

            if (rows[r2][c] != '-' && rows[r2][c] != '+')
                return false;
        }

        for (var r = r1 + 1; r < r2; r++)
        {
            if (rows[r][c1] != '|' && rows[r][c1] != '+')
                return false;

            if (rows[r][c2] != '|' && rows[r][c2] != '+')
                return false;
        }

        return true;
    }
}