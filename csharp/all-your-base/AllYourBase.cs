using System;
using System.Collections.Generic;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase <= 1)
        {
            throw new ArgumentException("Input base cannot be less than 2");
        }

        if (outputBase <= 1)
        {
            throw new ArgumentException("Output base cannot be less than 2");
        }
        int sum = 0;
        for (int i = 0; i < inputDigits.Length; i++)
        {
            int digit = inputDigits[inputDigits.Length - 1 - i];
            if (digit < 0)
            {
                throw new ArgumentException("Digits cannot be less than 0");
            }

            if (digit >= inputBase)
            {
                throw new ArgumentException("Digits cannot be more than or equal with the input base");
            }
            
            sum += ((int)Math.Pow(inputBase, i)) * digit;
        }

        int max = 0;
        while (sum / (int)Math.Pow(outputBase, max + 1) >= 1)
        {
            max++;
        }

        int[] output = new int[max + 1];

        for (int i = 0; i < output.Length; i++)
        {
            int baseVal = (int)Math.Pow(outputBase, output.Length - 1 - i);
            output[i] = sum / baseVal;
            sum -= output[i] * baseVal;
        }

        return output;
    }
}