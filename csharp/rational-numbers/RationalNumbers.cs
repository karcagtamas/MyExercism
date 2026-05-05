using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) =>
        r.Expreal(realNumber);
}

public struct RationalNumber
{
    private readonly int numerator;
    private readonly int denominator;

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero.");

        int gcd = Gcd(Math.Abs(numerator), Math.Abs(denominator));

        numerator /= gcd;
        denominator /= gcd;

        // normalize sign
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        this.numerator = numerator;
        this.denominator = denominator;
    }

    public int Numerator() => numerator;
    public int Denominator() => denominator;

    public RationalNumber Reduce()
    {
        int gcd = Gcd(Math.Abs(numerator), Math.Abs(denominator));

        int num = numerator / gcd;
        int den = denominator / gcd;

        if (den < 0)
        {
            num = -num;
            den = -den;
        }

        return new RationalNumber(num, den);
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            r1.numerator * r2.denominator + r2.numerator * r1.denominator,
            r1.denominator * r2.denominator
        );

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            r1.numerator * r2.denominator - r2.numerator * r1.denominator,
            r1.denominator * r2.denominator
        );

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            r1.numerator * r2.numerator,
            r1.denominator * r2.denominator
        );

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            r1.numerator * r2.denominator,
            r1.denominator * r2.numerator
        );

    public RationalNumber Abs() =>
        new RationalNumber(Math.Abs(numerator), Math.Abs(denominator));

    public RationalNumber Exprational(int power)
    {
        if (power == 0)
            return new RationalNumber(1, 1);

        if (power > 0)
        {
            return new RationalNumber(
                IntPow(numerator, power),
                IntPow(denominator, power)
            );
        }
        else
        {
            int p = Math.Abs(power);
            return new RationalNumber(
                IntPow(denominator, p),
                IntPow(numerator, p)
            );
        }
    }

    public double Expreal(double power) =>
        Math.Pow(numerator, power) / Math.Pow(denominator, power);

    public double Expreal(int realNumber) =>
        Math.Pow(realNumber, (double)numerator / denominator);

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private static int IntPow(int baseVal, int exp)
    {
        int result = 1;
        for (int i = 0; i < exp; i++)
            result *= baseVal;
        return result;
    }
}