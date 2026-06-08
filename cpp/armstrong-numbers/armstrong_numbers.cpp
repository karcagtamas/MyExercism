#include "armstrong_numbers.h"
#include <math.h>

namespace armstrong_numbers
{

    bool is_armstrong_number(unsigned int n)
    {
        int digits = 0;
        unsigned int temp = n;

        do
        {
            ++digits;
            temp /= 10;
        } while (temp > 0);

        unsigned int sum = 0;
        temp = n;

        do
        {
            int digit = temp % 10;
            sum += static_cast<unsigned int>(std::pow(digit, digits));
            temp /= 10;
        } while (temp > 0);

        return sum == n;
    }

} // namespace armstrong_numbers
