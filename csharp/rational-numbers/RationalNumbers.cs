using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) => r.Expreal(realNumber);
}

public struct RationalNumber
{
    public int Numerator { get; set; }
    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        int den = r1.Denominator * r2.Denominator;
        int num = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;
        return new RationalNumber(num, den).Reduce();
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        int den = r1.Denominator * r2.Denominator;
        int num = r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator;
        return new RationalNumber(num, den).Reduce();
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        int den = r1.Denominator * r2.Denominator;
        int num = r1.Numerator * r2.Numerator;
        return new RationalNumber(num, den).Reduce();
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        int den = r1.Denominator * r2.Numerator;
        int num = r1.Numerator * r2.Denominator;
        return new RationalNumber(num, den).Reduce();
    }

    public RationalNumber Abs()
    {
        int den = Denominator;
        int num = Numerator;

        if (den < 0)
        {
            den = -den;
            num = -num;
        }

        return new RationalNumber(num < 0 ? -num : num, den).Reduce();
    }

    public RationalNumber Reduce()
    {
        int num = Numerator;
        int den = Denominator;
        bool f = true;

        while (f)
        {
            int a = num < den ? num : den;
            a = a < 0 ? -a : a;
            if (a <= 1)
            {
                break;
            }

            bool dec = true;
            while (dec && f)
            {
                if (Denominator % a == 0 && Numerator % a == 0)
                {
                    num = Numerator / a;
                    den = Denominator / a;
                    dec = false;
                }
                else
                {
                    a--;
                    if (a <= 1)
                    {
                        f = false;
                    }
                }
            }

            if (!dec)
            {
                break;
            }
        }

        if (den < 0)
        {
            den = -den;
            num = -num;
        }

        return new RationalNumber(num, num == 0 ? 1 : den);
    }

    public RationalNumber Exprational(int power)
    {
        int num = (int)Math.Pow(Numerator, power);
        int den = (int)Math.Pow(Denominator, power);
        return new RationalNumber(num, den);
    }

    public double Expreal(int baseNumber) => Math.Pow(baseNumber, (double)Numerator / Denominator);
}