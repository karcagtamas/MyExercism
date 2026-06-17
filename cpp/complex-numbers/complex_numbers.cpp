#include "complex_numbers.h"
#include <cmath>

namespace complex_numbers
{

    Complex::Complex(double real, double imag) : _real(real), _imag(imag) {}

    double Complex::real() const
    {
        return _real;
    }

    double Complex::imag() const
    {
        return _imag;
    }

    Complex Complex::operator+(const Complex &other) const
    {
        return Complex{_real + other._real, _imag + other._imag};
    }

    Complex Complex::operator+(double other) const
    {
        return Complex{_real + other, _imag};
    }

    Complex Complex::operator-(const Complex &other) const
    {
        return Complex{_real - other._real, _imag - other._imag};
    }

    Complex Complex::operator-(double other) const
    {
        return Complex{_real - other, _imag};
    }

    Complex Complex::operator*(const Complex &other) const
    {
        return Complex{_real * other._real - _imag * other._imag, _imag * other._real + _real * other._imag};
    }

    Complex Complex::operator*(double other) const
    {
        return Complex{_real * other, _imag * other};
    }

    Complex Complex::operator/(const Complex &other) const
    {
        double denom = (pow(other._real, 2.0) + pow(other._imag, 2.0));
        double real = (_real * other._real + _imag * other._imag) / denom;
        double imag = (_imag * other._real - _real * other._imag) / denom;
        return Complex{real, imag};
    }

    Complex Complex::operator/(double other) const
    {
        return Complex{_real / other, _imag / other};
    }

    Complex operator+(double lhs, const Complex &rhs)
    {
        return Complex{lhs + rhs._real, rhs._imag};
    }

    Complex operator-(double lhs, const Complex &rhs)
    {
        return Complex{lhs - rhs._real, -rhs._imag};
    }

    Complex operator*(double lhs, const Complex &rhs)
    {
        return Complex{lhs * rhs._real, lhs * rhs._imag};
    }

    Complex operator/(double lhs, const Complex &rhs)
    {
        double denom = (pow(rhs._real, 2.0) + pow(rhs._imag, 2.0));
        return Complex{lhs * rhs._real / denom, -lhs * rhs._imag / denom};
    }

    double Complex::abs() const
    {
        return sqrt(pow(_real, 2.0) + pow(_imag, 2));
    }

    Complex Complex::exp() const
    {
        double first = pow(std::exp(1.0), _real);

        return Complex{first * cos(_imag), first * sin(_imag)};
    }

    Complex Complex::conj() const
    {
        return Complex{_real, -_imag};
    }

} // namespace complex_numbers
