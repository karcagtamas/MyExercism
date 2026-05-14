public enum ConnectWinner
{
    White,
    Black,
    None
}

public class Connect(string[] input)
{
    private readonly string[] _board = input;
    private readonly int _rows = input.Length;
    private readonly int _cols = input.Length == 0 ? 0 : input[0].Replace(" ", "").Length;

    public ConnectWinner Result()
    {
        if (HasWon('O'))
        {
            return ConnectWinner.White;
        }

        if (HasWon('X'))
        {
            return ConnectWinner.Black;
        }

        return ConnectWinner.None;
    }

    private bool HasWon(char player)
    {
        var visited = new HashSet<(int, int)>();
        var queue = new Queue<(int, int)>();

        if (player == 'O')
        {
            for (var col = 0; col < _cols; col++)
            {
                if (Cell(0, col) == 'O')
                {
                    queue.Enqueue((0, col));
                    visited.Add((0, col));
                }
            }

            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();

                if (row == _rows - 1)
                {
                    return true;
                }

                foreach (var neighbor in Neighbors(row, col))
                {
                    if (!visited.Contains(neighbor) && Cell(neighbor.Item1, neighbor.Item2) == 'O')
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
        else
        {
            for (var row = 0; row < _rows; row++)
            {
                if (Cell(row, 0) == 'X')
                {
                    queue.Enqueue((row, 0));
                    visited.Add((row, 0));
                }
            }

            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();

                if (col == _cols - 1)
                {
                    return true;
                }

                foreach (var neighbor in Neighbors(row, col))
                {
                    if (!visited.Contains(neighbor) && Cell(neighbor.Item1, neighbor.Item2) == 'X')
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        return false;
    }

    private IEnumerable<(int, int)> Neighbors(int row, int col)
    {
        var directions = new[]
        {
            (-1, 0),
            (-1, 1),
            (0, -1),
            (0, 1),
            (1, -1),
            (1, 0),
        };

        foreach (var (dr, dc) in directions)
        {
            var nr = row + dr;
            var nc = col + dc;

            if (nr >= 0 && nr < _rows && nc >= 0 && nc < _cols)
            {
                yield return (nr, nc);
            }
        }
    }

    private char Cell(int row, int col) => _board[row].Replace(" ", "")[col];
}