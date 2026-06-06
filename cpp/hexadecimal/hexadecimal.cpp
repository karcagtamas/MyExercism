#include "hexadecimal.h"

namespace hexadecimal
{

    int convert(const std::string &hex)
    {
        int result = 0;

        for (char c : hex)
        {
            int digit;

            if (std::isdigit(static_cast<unsigned char>(c)))
            {
                digit = c - '0';
            }
            else if (c >= 'a' && c <= 'f')
            {
                digit = c - 'a' + 10;
            }
            else if (c >= 'A' && c <= 'F')
            {
                digit = c - 'A' + 10;
            }
            else
            {
                return 0;
            }

            result = result * 16 + digit;
        }

        return result;
    }

} // namespace hexadecimal
