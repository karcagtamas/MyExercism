using System;

public struct ComplexNumber
{
    private readonly double _real;
    private readonly double _imaginary;

    public ComplexNumber(double real, double imaginary)
    {
        _real = real;
        _imaginary = imaginary;
    }

    public double Real() => _real;

    public double Imaginary() => _imaginary;

    public ComplexNumber Mul(ComplexNumber other) => new(Real() * other.Real() - Imaginary() * other.Imaginary(), Imaginary() * other.Real() + Real() * other.Imaginary());

    public ComplexNumber Mul(int other) => new(Real() * other, Imaginary() * other);

    public ComplexNumber Add(ComplexNumber other) => new(Real() + other.Real(), Imaginary() + other.Imaginary());

    public ComplexNumber Add(int other) => new(Real() + other, Imaginary());

    public ComplexNumber Sub(ComplexNumber other) => new(Real() - other.Real(), Imaginary() - other.Imaginary());

    public ComplexNumber Div(ComplexNumber other)
    {
        double real = (Real() * other.Real() + Imaginary() * other.Imaginary()) / (other.Real() * other.Real() + other.Imaginary() * other.Imaginary());
        double imaginary = (Imaginary() * other.Real() - Real() * other.Imaginary()) /
                        (Math.Pow(other.Real(), 2) + Math.Pow(other.Imaginary(), 2));
        return new(real, imaginary);
    }

    public ComplexNumber Div(int other) => new(Real() / other, Imaginary() / other);

    public double Abs() => Math.Sqrt(Math.Pow(Real(), 2) + Math.Pow(Imaginary(), 2));

    public ComplexNumber Conjugate() => new(Real(), -Imaginary());

    public ComplexNumber Exp()
    {
        double first = Math.Pow(Math.E, Real());
        return new(first * Math.Cos(Imaginary()), first * Math.Sin(Imaginary()));
    }
}