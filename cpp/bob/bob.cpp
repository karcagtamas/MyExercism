#include "bob.h"
#include <algorithm>

namespace bob
{

    std::string hey(const std::string &input)
    {
        bool only_whitespace = std::all_of(input.begin(), input.end(), [](unsigned char c)
                                           { return std::isspace(c); });

        if (only_whitespace)
            return "Fine. Be that way!";

        bool has_letter = false;
        bool all_letters_upper = true;

        for (unsigned char c : input)
        {
            if (std::isalpha(c))
            {
                has_letter = true;

                if (!std::isupper(c))
                {
                    all_letters_upper = false;
                }
            }
        }

        bool is_yelling = has_letter && all_letters_upper;

        auto last_non_space = std::find_if(input.rbegin(), input.rend(), [](unsigned char c)
                                           { return !std::isspace(c); });

        bool is_question = last_non_space != input.rend() && *last_non_space == '?';

        if (is_yelling && is_question)
        {
            return "Calm down, I know what I'm doing!";
        }

        if (is_question)
        {
            return "Sure.";
        }

        if (is_yelling)
        {
            return "Whoa, chill out!";
        }

        return "Whatever.";
    }

} // namespace bob
