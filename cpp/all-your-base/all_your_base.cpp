#include "all_your_base.h"
#include <stdexcept>
#include <algorithm>

namespace all_your_base
{

    std::vector<unsigned int> convert(unsigned int base, const std::vector<unsigned int> &digits, unsigned int output_base)
    {
        if (base < 2 || output_base < 2)
        {
            throw std::invalid_argument("Invalid base");
        }

        if (digits.empty())
        {
            return {};
        }

        unsigned long long value = 0;

        for (unsigned int digit : digits)
        {
            if (digit >= base)
                throw std::invalid_argument("Invalid digits");

            value = value * base + digit;
        }

        if (value == 0)
            return {};

        std::vector<unsigned int> result;

        while (value > 0)
        {
            result.push_back(value % output_base);
            value /= output_base;
        }

        std::reverse(result.begin(), result.end());

        return result;
    }

} // namespace all_your_base
