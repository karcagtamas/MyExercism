#include "binary_search.h"

#include <stdexcept>

namespace binary_search
{

    size_t find(const std::vector<int> &elements, int x)
    {
        if (elements.size() <= 0)
            throw std::domain_error("Elements must have at least one value");

        size_t left = 0;
        size_t right = elements.size();

        while (left < right)
        {
            size_t n = (right - left) / 2 + left;

            if (x < elements[n])
            {
                right = n;
            }
            else if (x > elements[n])
            {
                left = n + 1;
            }
            else
            {
                return n;
            }
        }

        throw std::domain_error("Value not found");
    }

} // namespace binary_search
