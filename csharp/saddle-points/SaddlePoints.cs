public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        var saddlePoints = new HashSet<(int, int)>();

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (IsMaxInRow(matrix, matrix[i, j], i) && IsMinInCol(matrix, matrix[i, j], j))
                {
                    saddlePoints.Add((i + 1, j + 1));
                }
            }
        }

        return saddlePoints;
    }

    private static bool IsMaxInRow(int[,] matrix, int value, int rowIndex)
    {
        for (var j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] > value)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsMinInCol(int[,] matrix, int value, int colIndex)
    {
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, colIndex] < value)
            {
                return false;
            }
        }

        return true;
    }
}
