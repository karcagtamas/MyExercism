#include "perfect_numbers.h"
#include <stdexcept>

namespace perfect_numbers
{

    classification classify(int number)
    {
        if (number <= 0)
        {
            throw std::domain_error("Not natural number");
        }

        int divisor_sum = 1;

        for (int i = 2; i * i <= number; ++i)
        {
            if (number % i == 0)
            {
                divisor_sum += i;

                if (i != number / i)
                {
                    divisor_sum += number / i;
                }
            }
        }

        if (number == 1)
        {
            divisor_sum = 0;
        }

        if (divisor_sum < number)
        {
            return classification::deficient;
        }
        else if (divisor_sum > number)
        {
            return classification::abundant;
        }

        return classification::perfect;
    }

} // namespace perfect_numbers
