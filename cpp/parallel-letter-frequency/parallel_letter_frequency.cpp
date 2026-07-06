#include "parallel_letter_frequency.h"
#include <cctype>
#include <future>

namespace parallel_letter_frequency
{

    static std::unordered_map<char, int> count(std::string_view text)
    {
        std::unordered_map<char, int> result;

        for (unsigned char c : text)
        {
            if (std::isalpha(c))
            {
                ++result[std::tolower(c)];
            }
        }

        return result;
    }

    std::unordered_map<char, int> frequency(const std::vector<std::string_view> &texts)
    {
        std::vector<std::future<std::unordered_map<char, int>>> futures;

        for (std::string_view text : texts)
        {
            futures.push_back(std::async(std::launch::async, count, text));
        }

        std::unordered_map<char, int> result{};

        for (auto &future : futures)
        {
            auto partial = future.get();

            for (const auto &[letter, count] : partial)
            {
                result[letter] += count;
            }
        }

        return result;
    }
}
