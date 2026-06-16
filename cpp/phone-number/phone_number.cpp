#include "phone_number.h"
#include <stdexcept>

namespace phone_number
{

    std::string phone_number::number() const
    {
        return num;
    }

    phone_number::phone_number(const std::string &input)
    {
        std::string digits;

        for (char c : input)
        {
            if (std::isdigit(static_cast<unsigned char>(c)))
            {
                digits += c;
            }
            else if (std::isalpha(static_cast<unsigned char>(c)))
            {
                throw std::domain_error("Letters are not permitted");
            }
            else if (c == ' ' || c == '(' || c == ')' || c == '-' || c == '.' || c == '+')
            {
            }
            else
            {
                throw std::domain_error("Punctuation is not permitted");
            }
        }

        if (digits.size() == 11)
        {
            if (digits[0] != '1')
            {
                throw std::domain_error("11 digits must start with 1");
            }

            digits.erase(0, 1);
        }
        else if (digits.size() != 10)
        {
            throw std::domain_error("Incorrect number of digits");
        }

        if (digits[0] < '2')
        {
            throw std::domain_error("Area code cannot star with 0 or 1");
        }

        if (digits[3] < '2')
        {
            throw std::domain_error("Exchange code cannot start with 0 or 1");
        }

        num = digits;
    }

} // namespace phone_number
