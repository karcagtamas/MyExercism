using System;

public static class DifferenceOfSquares {
    public static int CalculateSquareOfSum (int max) {
        int sum = ((max + 1) * (int) (max / 2)) + ((max % 2) == 0 ? 0 : (int) Math.Ceiling ((double) max / 2));
        return (int) Math.Pow (sum, 2);
    }

    public static int CalculateSumOfSquares (int max) {
        int sum = 0;
        for (int i = 1; i <= max; i++) {
            sum += (int) Math.Pow (i, 2);
        }
        return sum;
    }

    public static int CalculateDifferenceOfSquares (int max) {
        return CalculateSquareOfSum (max) - CalculateSumOfSquares (max);
    }
}