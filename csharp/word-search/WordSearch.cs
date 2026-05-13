public class WordSearch(string grid)
{
    private readonly string[] _grid = grid.Split('\n');
    private static readonly (int dx, int dy)[] Directions = [
      (-1, -1),
      (-1, 0),
      (-1, 1),
      (0, -1),
      (0, 1),
      (1, -1),
      (1, 0),
      (1, 1),
    ];

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var result = new Dictionary<string, ((int, int), (int, int))?>();

        foreach (var word in wordsToSearchFor)
        {
            result[word] = FindWord(word);
        }

        return result;
    }

    private ((int, int), (int, int))? FindWord(string word)
    {
        var rows = _grid.Length;
        var cols = _grid[0].Length;

        for (var y = 0; y < rows; y++)
        {
            for (var x = 0; x < cols; x++)
            {
                foreach (var (dx, dy) in Directions)
                {
                    if (Matches(word, x, y, dx, dy))
                    {
                        var endX = x + dx * (word.Length - 1);
                        var endY = y + dy * (word.Length - 1);

                        return ((x + 1, y + 1), (endX + 1, endY + 1));
                    }
                }
            }
        }

        return null;
    }

    private bool Matches(string word, int startX, int startY, int dx, int dy)
    {
        var rows = _grid.Length;
        var cols = _grid[0].Length;

        for (var i = 0; i < word.Length; i++)
        {
            var x = startX + dx * i;
            var y = startY + dy * i;

            if (x < 0 || y < 0 || x >= cols || y >= rows)
            {
                return false;
            }

            if (_grid[y][x] != word[i])
            {
                return false;
            }
        }

        return true;
    }
}