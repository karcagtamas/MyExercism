public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        if (input.Length == 0)
        {
            return -1;
        }

        var n = input.Length / 2;

        if (value < input[n])
        {
            return Find(input[..n], value);
        } else if (value > input[n])
        {
            var res = Find(input[(n + 1)..], value);

            return res == -1 ? -1 : res + n + 1;
        }

        return n;
    }
}