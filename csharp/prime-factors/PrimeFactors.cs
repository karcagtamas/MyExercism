using System;
using System.Collections.Generic;

public static class PrimeFactors {
    public static long[] Factors (long number) {
        List<long> list = new List<long> ();
        long currentPrime = 2;
        while (number != 1) {
            if (number % currentPrime == 0) {
                list.Add (currentPrime);
                number = number / currentPrime;
            } else {
                do {
                    currentPrime++;
                } while (!IsPrime (currentPrime));
            }
        }
        return list.ToArray ();
    }

    public static bool IsPrime (long val) {
        bool f = true;
        for (int i = 2; i < Math.Sqrt (val) && f; i++) {
            if (val % i == 0) {
                f = false;
            }
        }
        return f;
    }
}