#include "luhn.h"

namespace luhn
{

    bool valid(const std::string &formula)
    {
        int sum = 0;
        int count = 0;
        bool dbl = false;

        for (int i = formula.length() - 1; i >= 0; i--)
        {
            char ch = formula[i];

            if (ch == ' ')
                continue;
            if (ch < '0' || ch > '9')
                return false;

            int digit = ch - '0';

            if (dbl)
            {
                digit *= 2;
                if (digit > 9)
                    digit -= 9;
            }

            sum += digit;
            dbl = !dbl;
            count++;
        }

        return count > 1 && sum % 10 == 0;
    }

} // namespace luhn
