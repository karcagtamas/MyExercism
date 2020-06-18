using System;
using System.Collections.Generic;
using System.Linq;

public static class LargestSeriesProduct {
    public static long GetLargestProduct (string digits, int span) {
        if (digits.Length < span || span < 0) {
            throw new ArgumentException ();
        }
        long result = 0;
        for (int i = 0; i < digits.Length - span + 1; i++) {
            string s = digits.Substring (i, span);
            long sum = 1;
            for (int j = 0; j < s.Length; j++) {
                int digit;
                if (!int.TryParse (s[j].ToString (), out digit)) {
                    throw new ArgumentException ();
                }
                sum *= int.Parse (s[j].ToString ());
            }

            if (sum > result) {
                result = sum;
            }
        }

        return result;
    }
}