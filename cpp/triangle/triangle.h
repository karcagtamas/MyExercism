#pragma once

namespace triangle
{

    enum flavor
    {
        equilateral,
        isosceles,
        scalene
    };

    bool equal(double x, double y);

    bool valid(double a, double b, double c);

    flavor kind(double a, double b, double c);

} // namespace triangle
