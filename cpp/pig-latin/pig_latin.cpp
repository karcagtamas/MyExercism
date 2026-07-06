#include "pig_latin.h"
#include <sstream>
#include <algorithm>

namespace pig_latin
{
    static bool is_vowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }

    static std::size_t first_consonant_cluster_end(const std::string &word)
    {
        for (std::size_t i = 0; i < word.size(); ++i)
        {
            if (is_vowel(word[i]))
                return i;
        }

        return word.size();
    }

    std::string translate_word(const std::string &word)
    {
        std::size_t idx = first_consonant_cluster_end(word);
        std::size_t qu_index = word.find("qu");
        std::size_t y_index = word.find('y');
        if (is_vowel(word[0]) || word.compare(0, 2, "xr") == 0 || word.compare(0, 2, "yt") == 0)
        {
            return word + "ay";
        }
        if (qu_index != std::string::npos && qu_index < idx)
        {
            return word.substr(qu_index + 2) + word.substr(0, qu_index + 2) + "ay";
        }
        if (y_index != std::string::npos && y_index > 0 && std::all_of(word.begin(), word.begin() + y_index, [](char c)
                                                                       { return !is_vowel(c); }))
        {
            return word.substr(y_index) + word.substr(0, y_index) + "ay";
        }
        return word.substr(idx) + word.substr(0, idx) + "ay";
    }

    std::string translate(const std::string &text)
    {
        std::stringstream input(text);
        std::ostringstream output;
        std::string word;
        bool first = true;
        while (input >> word)
        {
            if (!first)
            {
                output << ' ';
            }
            output << translate_word(word);
            first = false;
        }
        return output.str();
    }

} // namespace pig_latin
