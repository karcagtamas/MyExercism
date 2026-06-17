#include "roman_numerals.h"
#include <vector>
#include <utility>

namespace roman_numerals
{
    const std::vector<std::pair<std::string, int>> ROMAN_NUMBERS{
        {"M", 1000},
        {"CM", 900},
        {"D", 500},
        {"CD", 400},
        {"C", 100},
        {"XC", 90},
        {"L", 50},
        {"XL", 40},
        {"X", 10},
        {"IX", 9},
        {"V", 5},
        {"IV", 4},
        {"I", 1}};

    std::string find_nearest_number(int number)
    {
        for (const auto &[key, value] : ROMAN_NUMBERS)
        {
            if (value <= number)
            {
                return key;
            }
        }

        return "I";
    }

    std::string convert(int value)
    {
        if (value == 0)
        {
            return "";
        }

        std::string key = find_nearest_number(value);

        std::string roman = key;

        if (value != ROMAN_NUMBERS[0].second)
        {
            int number = 0;

            for (const auto &[k, v] : ROMAN_NUMBERS)
            {
                if (k == key)
                {
                    number = v;
                    break;
                }
            }

            roman += convert(value - number);
        }

        return roman;
    }

} // namespace roman_numerals
