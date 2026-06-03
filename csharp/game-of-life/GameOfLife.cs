using System;

public static class GameOfLife
{
    public static int[,] Tick(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        var next = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                var neighbors = CountNeighbors(matrix, row, col);

                next[row, col] = matrix[row, col] == 1 
                    ? neighbors == 2 || neighbors == 3 
                        ? 1 
                        : 0 
                    : neighbors == 3 
                        ? 1 
                        : 0;
            }
        }

        return next;
    }

    private static int CountNeighbors(int[,] matrix, int row, int col)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int count = 0;

        for (int dr = -1; dr <= 1; dr++)
        {
            for (int dc = -1; dc <= 1; dc++)
            {
                if (dr == 0 && dc == 0) continue;

                int r = row + dr;
                int c = col + dc;

                if (r >= 0 && r < rows && c >= 0 && c < cols)
                {
                    count += matrix[r, c];
                }
            }
        }

        return count;
    }
}
