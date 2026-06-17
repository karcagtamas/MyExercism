#pragma once

namespace complex_numbers
{

    class Complex
    {
    public:
        Complex(double real, double imag);
        double real() const;
        double imag() const;

        Complex operator+(const Complex &other) const;
        Complex operator+(double other) const;
        Complex operator-(const Complex &other) const;
        Complex operator-(double other) const;
        Complex operator*(const Complex &other) const;
        Complex operator*(double other) const;
        Complex operator/(const Complex &other) const;
        Complex operator/(double other) const;

        friend Complex operator+(double lhs, const Complex &rhs);
        friend Complex operator-(double lhs, const Complex &rhs);
        friend Complex operator*(double lhs, const Complex &rhs);
        friend Complex operator/(double lhs, const Complex &rhs);

        double abs() const;
        Complex exp() const;
        Complex conj() const;

    private:
        double _real;
        double _imag;
    };

} // namespace complex_numbers
