using System.Numerics;

public static class DiffieHellman
{
    private static readonly BigInteger TWO = new(2);

    public static BigInteger PrivateKey(BigInteger primeP) 
    {
        var rnd = new Random();
        while (true)
        {
            BigInteger candidate = rnd.NextInt64(2, (long)primeP);

            if (candidate >= TWO && candidate < primeP)
            {
                return candidate;
            }
        }
    }

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey) => BigInteger.ModPow(primeG, privateKey, primeP);

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey) => BigInteger.ModPow(publicKey, privateKey, primeP);
}