#include "anagram.h"
#include <algorithm>

namespace anagram
{

    anagram::anagram(const std::string &word) : word(word) {}

    std::string anagram::normalize(const std::string &word)
    {
        std::string result = word;

        for (char &c : result)
        {
            c = static_cast<char>(std::tolower(static_cast<unsigned char>(c)));
        }

        std::sort(result.begin(), result.end());

        return result;
    }

    std::string anagram::lowercase(const std::string &word)
    {
        std::string result = word;

        for (char &c : result)
        {
            c = static_cast<char>(
                std::tolower(static_cast<unsigned char>(c)));
        }

        return result;
    }

    std::vector<std::string> anagram::matches(const std::vector<std::string> &candidates) const
    {
        std::vector<std::string> result;

        auto target_sorted = normalize(word);
        auto target_lower = lowercase(word);

        for (const auto &candidate : candidates)
        {
            if (lowercase(candidate) == target_lower)
                continue;

            if (normalize(candidate) == target_sorted)
                result.push_back(candidate);
        }

        return result;
    }

} // namespace anagram
