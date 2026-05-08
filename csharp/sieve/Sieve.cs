public static class Sieve
{
    public static int[] Primes(int limit)
    {
        List<int> primes = [];

        for (var i = 2; i <= limit; i++)
        {
            if (i == 2)
            {
                primes.Add(i);
                continue;
            }

            if (i % 2 == 0)
            {
                continue;
            }

            var hasDivisor = false;
            for (var x = 3; x <= (int)Math.Sqrt(i); x++)
            {
                if (i % x == 0)
                {
                    hasDivisor = true;
                    break;
                }
            } 

            if (!hasDivisor)
            {
                primes.Add(i);
            }
        }

        return [.. primes];
    }
}