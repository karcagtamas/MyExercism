#include "isbn_verifier.h"

namespace isbn_verifier
{

    bool is_valid(const std::string &number)
    {
        int sum{};
        int count{};

        for (auto ch : number)
        {
            if (ch == '-')
                continue;

            count++;

            int value;

            if (isdigit(ch))
            {
                value = ch - '0';
            }
            else if (ch == 'X' && count == 10)
            {
                value = 10;
            }
            else
            {
                return false;
            }

            sum += value * (11 - count);
        }

        return count == 10 && sum % 11 == 0;
    }

} // namespace isbn_verifier
