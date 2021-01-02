#include "hamming.h"
#include <stdexcept>
#include <algorithm>

namespace hamming
{
    unsigned int compute(const std::string &a, const std::string &b)
    {
        if (a.length() != b.length())
        {
            throw std::domain_error("A and B text lengths have to be same");
        }

        unsigned int c = 0;

        for (size_t i = 0; i < a.length(); i++)
        {
            if (a[i] != b[i])
            {
                c++;
            }
        }

        return c;
    }
} // namespace hamming
