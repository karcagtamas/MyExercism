#include "triangle.h"
#include <stdexcept>

namespace triangle
{
    bool equal(double x, double y)
    {
        return x - y == 0;
    }

    bool valid(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    flavor kind(double a, double b, double c)
    {
        if (!valid(a, b, c))
        {
            throw std::domain_error("Triangle is invalid");
        }

        if (equal(a, b) && equal(a, c) && equal(b, c) && a != 0)
        {
            return flavor::equilateral;
        }

        if (equal(a, b) || equal(a, c) || equal(b, c))
        {
            return flavor::isosceles;
        }

        return flavor::scalene;
    }

} // namespace triangle
