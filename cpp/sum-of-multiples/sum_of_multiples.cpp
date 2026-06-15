#include "sum_of_multiples.h"

namespace sum_of_multiples
{

    int to(std::vector<int> multiples, long unsigned int max)
    {
        int sum = 0;

        for (size_t i = 1; i < max; i++)
        {
            for (size_t x = 0; x < multiples.size(); x++)
            {
                if (multiples[x] != 0 && i % multiples[x] == 0)
                {
                    sum += i;
                    break;
                }
            }
        }

        return sum;
    }

} // namespace sum_of_multiples
