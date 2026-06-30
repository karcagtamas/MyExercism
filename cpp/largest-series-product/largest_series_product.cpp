#include "largest_series_product.h"
#include <stdexcept>

namespace largest_series_product
{

    long long largest_product(const std::string &digits, std::size_t span)
    {
        if (span > digits.size())
            throw std::domain_error("Span is longer than string");

        for (char c : digits)
        {
            if (!std::isdigit(static_cast<unsigned char>(c)))
                throw std::domain_error("Invalid digit");
        }

        if (span == 0)
            return 1;

        long long largest = 0;

        for (std::size_t i = 0; i <= digits.size() - span; i++)
        {
            long long product = 1;

            for (std::size_t j = 0; j < span; j++)
            {
                product *= digits[i + j] - '0';
            }

            if (product > largest)
                largest = product;
        }

        return largest;
    }

} // namespace largest_series_product
