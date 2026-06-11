#include "prime_factors.h"
#include <cmath>

namespace prime_factors
{

    bool is_prime(long long n)
    {
        for (long long i = 2; i <= (long long)sqrt(n); i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    std::vector<long long> of(long long n)
    {
        std::vector<long long> result;
        long long current = 2;

        while (n != 1)
        {
            if (n % current == 0)
            {
                result.push_back(current);
                n = n / current;
            }
            else
            {
                do
                {
                    current++;
                } while (!is_prime(current));
            }
        }

        return result;
    }

} // namespace prime_factors
