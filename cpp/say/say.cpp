#include "say.h"
#include <array>
#include <vector>
#include <stdexcept>

namespace say
{

    static const std::array<std::string, 20> small{
        "zero",
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine",
        "ten",
        "eleven",
        "twelve",
        "thirteen",
        "fourteen",
        "fifteen",
        "sixteen",
        "seventeen",
        "eighteen",
        "nineteen"};

    static const std::array<std::string, 10> tens{
        "",
        "",
        "twenty",
        "thirty",
        "forty",
        "fifty",
        "sixty",
        "seventy",
        "eighty",
        "ninety"};

    static const std::array<std::string, 4> scales{
        "",
        "thousand",
        "million",
        "billion"};

    std::string say_under_1000(long num)
    {
        std::vector<std::string> parts;

        long hundreds = num / 100;
        long remainder = num % 100;

        if (hundreds > 0)
        {
            parts.push_back(std::string(small[hundreds]) + " hundred");
        }

        if (remainder > 0)
        {
            if (remainder < 20)
            {
                parts.push_back(small[remainder]);
            }
            else if (remainder % 10 == 0)
            {
                parts.push_back(tens[remainder / 10]);
            }
            else
            {
                parts.push_back(std::string(tens[remainder / 10]) + "-" + small[remainder % 10]);
            }
        }

        std::string result;

        for (size_t i = 0; i < parts.size(); i++)
        {
            if (i > 0)
            {
                result += ' ';
            }

            result += parts[i];
        }

        return result;
    }

    std::string in_english(long number)
    {
        if (number < 0 || number > 999999999999L)
            throw std::domain_error("Out of range");

        if (number == 0)
            return "zero";

        long num = number;
        int scale_index = 0;

        std::vector<std::string> parts;

        while (num > 0)
        {
            int chunk = (int)(num % 1000);

            if (chunk != 0)
            {
                std::string chunk_text = say_under_1000(chunk);
                std::string scale = scales[scale_index];

                parts.push_back(scale == "" ? chunk_text : chunk_text + " " + scale);
            }

            num /= 1000;
            scale_index++;
        }

        std::string result;

        for (auto it = parts.rbegin(); it != parts.rend(); ++it)
        {
            if (!result.empty())
            {
                result += ' ';
            }

            result += *it;
        }

        return result;
    }

} // namespace say
