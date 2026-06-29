#include "binary.h"

namespace binary
{

    int convert(const std::string &bits)
    {
        int result = 0;

        for (char bit : bits)
        {
            if (bit != '0' && bit != '1')
            {
                return 0;
            }

            result *= 2;
            result += bit - '0';
        }

        return result;
    }

} // namespace binary
