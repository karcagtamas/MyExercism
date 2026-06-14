#include "grains.h"
#include <cmath>

namespace grains
{

    unsigned long long square(int n)
    {
        if (n <= 0 || n > 64)
        {
            return 0;
        }

        return pow(2, n - 1);
    }

    unsigned long long total()
    {
        long long sum = 0;

        for (int i = 1; i <= 64; i++)
        {
            sum += square(i);
        }

        return sum;
    }

} // namespace grains
