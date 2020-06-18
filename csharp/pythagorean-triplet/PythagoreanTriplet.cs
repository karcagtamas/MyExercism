using System;
using System.Collections.Generic;

public static class PythagoreanTriplet {
    public static IEnumerable < (int a, int b, int c) > TripletsWithSum (int sum) {
        List < (int a, int b, int c) > list = new List < (int a, int b, int c) > ();
        for (int i = 1; i < sum; i++) {
            for (int j = i; i + j < sum; j++) {
                for (int k = j; i + j + k <= sum; k++) {
                    if (i + j + k == sum) {
                        if (Math.Pow (i, 2) + Math.Pow (j, 2) == Math.Pow (k, 2)) {
                            list.Add ((i, j, k));
                        }
                    }
                }
            }
        }
        return list;
    }
}