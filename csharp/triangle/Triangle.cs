using System;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        return IsValid(side1, side2, side3) && !IsEqual(side1, side2) && !IsEqual(side1, side3) && !IsEqual(side2, side3);
    }

    public static bool IsIsosceles(double side1, double side2, double side3)
    {
        return IsValid(side1, side2, side3) && (IsEqual(side1, side2) || IsEqual(side1, side3) || IsEqual(side2, side3));
    }

    public static bool IsEquilateral(double side1, double side2, double side3)
    {
        return IsEqual(side1, side2) && IsEqual(side1, side3) && IsEqual(side2, side3) && side1 != 0;
    }

    private static bool IsEqual(double sideA, double sideB)
    {
        return Math.Abs(sideA - sideB) == 0;
    }

    private static bool IsValid(double side1, double side2, double side3)
    {
        return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
    }
}