#include "word_count.h"
#include <regex>

namespace word_count
{

    std::map<std::string, int> words(const std::string &phrase)
    {
        std::map<std::string, int> words;
        std::string input = phrase;
        for (char &c : input)
        {
            c = static_cast<char>(std::tolower(static_cast<unsigned char>(c)));
        }

        std::regex regex_pattern("[A-Za-z0-9]+(?:'[A-Za-z0-9]+)*");

        auto begin = std::sregex_iterator(input.begin(), input.end(), regex_pattern);
        auto end = std::sregex_iterator();

        for (auto it = begin; it != end; ++it)
        {
            std::string word = it->str();
            words[word]++;
        }

        return words;
    }

} // namespace word_count
