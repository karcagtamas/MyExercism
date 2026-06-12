#include "alphametics.h"

#include <algorithm>

namespace alphametics
{

    bool dfs(int idx, const std::vector<char> &letters, std::unordered_map<char, int> &assign, int used, const std::unordered_map<char, long long> &coeff, const std::unordered_set<char> &leading)
    {
        if (idx == (int)letters.size())
        {
            long long sum = 0;

            for (auto &[c, w] : coeff)
            {
                sum += w * assign[c];
            }

            return sum == 0;
        }

        char c = letters[idx];

        for (int d = 0; d <= 9; ++d)
        {
            if (used & (1 << d))
                continue;

            if (d == 0 && leading.count(c))
                continue;

            assign[c] = d;

            if (dfs(idx + 1, letters, assign, used | (1 << d), coeff, leading))
                return true;

            assign.erase(c);
        }

        return false;
    }

    std::optional<std::unordered_map<char, int>> solve(const std::string &puzzle)
    {
        std::unordered_map<char, long long> coeff;
        std::unordered_set<char> letters_set;
        std::unordered_set<char> leading;

        int sign = 1;

        int n = (int)puzzle.size();
        int pos = 0;

        while (pos < n)
        {
            if (puzzle[pos] == ' ')
            {
                pos++;
                continue;
            }

            if (puzzle[pos] == '+')
            {
                pos++;
                continue;
            }

            if (puzzle[pos] == '=')
            {
                sign = -1;
                pos++;
                continue;
            }

            std::string word;

            while (pos < n && std::isalpha(puzzle[pos]))
            {
                word += puzzle[pos];
                pos++;
            }

            if (!word.empty())
            {
                if (word.size() > 1)
                {
                    leading.insert(word[0]);
                }

                long long place = 1;

                for (int i = (int)word.size() - 1; i >= 0; i--)
                {
                    char c = word[i];
                    coeff[c] += sign * place;
                    letters_set.insert(c);
                    place *= 10;
                }
            }
        }

        std::vector<char> letters(letters_set.begin(), letters_set.end());
        std::unordered_map<char, int> assign;
        int used = 0;

        bool ok = dfs(0, letters, assign, used, coeff, leading);

        if (!ok)
        {
            return std::nullopt;
        }

        return assign;
    }

} // namespace alphametics
