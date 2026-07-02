#include "run_length_encoding.h"

namespace run_length_encoding
{

    std::string encode(const std::string &input)
    {
        if (input.empty())
            return input;

        std::string result{};

        char latest = input[0];
        int count = 1;

        for (size_t i = 1; i < input.size(); i++)
        {
            if (input[i] == latest)
            {
                count++;
            }
            else
            {
                if (count > 1)
                {
                    result += std::to_string(count);
                }

                result += latest;
                latest = input[i];
                count = 1;
            }
        }

        if (count > 1)
            result += std::to_string(count);
        result += latest;

        return result;
    }

    std::string decode(const std::string &input)
    {
        if (input.empty())
            return input;

        std::string result{};
        int count = 0;

        for (auto c : input)
        {
            if (isdigit(static_cast<unsigned char>(c)))
            {
                count = count * 10 + (c - '0');
            }
            else
            {
                int repeat = (count == 0) ? 1 : count;
                result.append(repeat, c);
                count = 0;
            }
        }

        return result;
    }

} // namespace run_length_encoding
