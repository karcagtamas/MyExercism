public class Matrix(string input)
{
    private readonly int[][] m = [.. input.Split('\n').Select(r => r.Split(' ').Select(i => int.Parse(i)).ToArray())];

    public int[] Row(int row) => m[row - 1];

    public int[] Column(int col) => [.. m.Select(r => r[col - 1])];
}