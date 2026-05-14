public enum Owner
{
    None,
    Black,
    White
}

public class GoCounting(string input)
{
    private readonly string[] _board = input.Split('\n');

    public Tuple<Owner, HashSet<(int, int)>> Territory((int, int) coord)
    {
        var (x, y) = coord;

        if (!InBounds(x, y))
        {
            throw new ArgumentException();
        }

        if (_board[y][x] != ' ')
        {
            return Tuple.Create(Owner.None, new HashSet<(int, int)>());
        }

        var territory = new HashSet<(int, int)>();
        var bordering = new HashSet<char>();

        var queue = new Queue<(int, int)>();
        queue.Enqueue(coord);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (territory.Contains(current))
            {
                continue;
            }

            territory.Add(current);

            foreach (var neighbor in Neighbors(current))
            {
                var cell = _board[neighbor.Item2][neighbor.Item1];

                if (cell == ' ')
                {
                    if (!territory.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
                else
                {
                    bordering.Add(cell);
                }
            }
        }

        var owner = bordering.Count == 1
            ? bordering.Single() switch
            {
                'B' => Owner.Black,
                'W' => Owner.White,
                _ => Owner.None,
            }
            : Owner.None;

        return Tuple.Create(owner, territory);
    }

    public Dictionary<Owner, HashSet<(int, int)>> Territories()
    {
        var result = new Dictionary<Owner, HashSet<(int, int)>>
        {
            [Owner.Black] = [],
            [Owner.White] = [],
            [Owner.None] = [],
        };

        var visited = new HashSet<(int, int)>();

        for (var y = 0; y < _board.Length; y++)
        {
            for (var x = 0; x < _board[y].Length; x++)
            {
                if (_board[y][x] != ' ' || visited.Contains((x, y)))
                {
                    continue;
                }

                var territory = Territory((x, y));

                foreach (var pos in territory.Item2)
                {
                    visited.Add(pos);
                }

                result[territory.Item1].UnionWith(territory.Item2);
            }
        }

        return result;
    }

    private IEnumerable<(int, int)> Neighbors((int x, int y) coord)
    {
        var (x, y) = coord;

        var directions = new[]
        {
            (0, -1),
            (0, 1),
            (-1, 0),
            (1, 0),
        };

        foreach (var (dx, dy) in directions)
        {
            var nx = x + dx;
            var ny = y + dy;

            if (InBounds(nx, ny))
            {
                yield return (nx, ny);
            }
        }
    }

    private bool InBounds(int x, int y) => y >= 0 && y < _board.Length && x >= 0 && x < _board[y].Length;
}
