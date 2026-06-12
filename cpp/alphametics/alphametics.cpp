#include "alphametics.h"

#include <vector>
#include <set>
#include <algorithm>

namespace alphametics
{

    long long word_value(const std::string &word, const std::map<char, int> &m)
    {
        long long value = 0;

        for (char c : word)
        {
            value = value * 10 + m.at(c);
        }

        return value;
    }

    std::optional<std::map<char, int>> solve(const std::string &puzzle)
    {
        std::vector<std::string> words;
        std::set<char> letters;
        std::set<char> leading;

        std::string current;

        for (char c : puzzle)
        {
            if (std::isalpha(c))
            {
                current += c;
                letters.insert(c);
            }
            else
            {
                if (!current.empty())
                {
                    words.push_back(current);
                    current.clear();
                }
            }
        }

        if (!current.empty())
        {
            words.push_back(current);
        }

        for (const auto &w : words)
        {
            if (w.size() > 1)
            {
                leading.insert(w.front());
            }
        }

        std::vector<char> chars(letters.begin(), letters.end());
        std::vector<int> digits{0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

        if (chars.size() > 10)
            return std::nullopt;

        do
        {
            std::map<char, int> mapping;

            for (size_t i = 0; i < chars.size(); i++)
            {
                mapping[chars[i]] = digits[i];
            }

            bool ok = true;

            for (char c : leading)
            {
                if (mapping[c] == 0)
                {
                    ok = false;
                    break;
                }
            }

            if (!ok)
                continue;

            long long sum = 0;

            for (size_t i = 0; i < words.size() - 1; i++)
            {
                sum += word_value(words[i], mapping);
            }

            long long rhs = word_value(words.back(), mapping);

            if (sum == rhs)
            {
                return mapping;
            }
        } while (std::next_permutation(digits.begin(), digits.end()));

        return std::nullopt;
    }

} // namespace alphametics
