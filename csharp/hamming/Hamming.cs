using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        Validate(firstStrand, secondStrand);
        int count = 0;

        for (int i = 0; i < firstStrand.Length; i++)
        {
            if (firstStrand[i] != secondStrand[i])
            {
                count++;
            }
        }

        return count;
    }

    public static void Validate(string firstStrand, string secondStrand)
    {
        if (String.IsNullOrEmpty(firstStrand) && !String.IsNullOrEmpty(secondStrand))
        {
            throw new ArgumentException("The first one is empty.");
        }
        if (String.IsNullOrEmpty(secondStrand) && !String.IsNullOrEmpty(firstStrand))
        {
            throw new ArgumentException("The second one is empty.");
        }
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException("The given values's length is not equal");
        }
    }
}