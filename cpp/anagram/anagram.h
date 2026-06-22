#pragma once

#include <string>
#include <vector>

namespace anagram
{

    class anagram
    {
    public:
        anagram(const std::string &word);

        std::vector<std::string> matches(const std::vector<std::string> &candidates) const;

    private:
        std::string word;

        static std::string lowercase(const std::string &word);
        static std::string normalize(const std::string &word);
    };

} // namespace anagram
