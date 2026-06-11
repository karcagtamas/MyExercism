#include "sieve.h"
#include <cmath>

namespace sieve
{

    std::vector<int> primes(int limit)
    {
        std::vector<int> result;

        for (int i = 2; i <= limit; i++)
        {
            if (i == 2)
            {
                result.push_back(i);
                continue;
            }

            if (i % 2 == 0)
            {
                continue;
            }

            bool hasDivisor = false;

            for (int x = 3; x <= (int)sqrt(i); x++)
            {
                if (i % x == 0)
                {
                    hasDivisor = true;
                    break;
                }
            }

            if (!hasDivisor)
            {
                result.push_back(i);
            }
        }

        return result;
    }

} // namespace sieve
