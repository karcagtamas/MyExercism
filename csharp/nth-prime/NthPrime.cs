public static class NthPrime
{
    public static int Prime(int nth)
    {
        if (nth <= 0) throw new ArgumentOutOfRangeException("There is no zeroth prime.");

        var x = 2;
        var c = 1;

        while (c < nth)
        {
            x++;

            if (IsPrime(x))
            {
                c++;
            }
        }

        return x;
    }

    private static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        for (var i = 3; i <= Math.Sqrt(n); i += 2)
        {
            if (n % i == 0) return false;
        }

        return true;
    }
}