#include "nth_prime.h"
#include <cmath>
#include <stdexcept>

namespace nth_prime
{

    bool is_prime(int x)
    {
        if (x < 2)
            return false;
        if (x == 2)
            return true;
        if (x % 2 == 0)
            return false;

        for (int i = 3; i <= sqrt(x); i += 2)
        {
            if (x % i == 0)
                return false;
        }

        return true;
    }

    int nth(int n)
    {
        if (n <= 0)
            throw std::domain_error("There is no zeroth prime.");

        int x = 2;
        int c = 1;

        while (c < n)
        {
            x++;
            if (is_prime(x))
            {
                c++;
            }
        }

        return x;
    }

} // namespace nth_prime
