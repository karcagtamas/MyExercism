#include "isogram.h"
#include <unordered_set>

namespace isogram
{

    bool is_isogram(const std::string &phrase)
    {
        std::unordered_set<char> seen;

        for (char c : phrase)
        {
            if (c == ' ' || c == '-')
            {
                continue;
            }

            char letter = static_cast<char>(std::tolower(static_cast<unsigned char>(c)));

            if (seen.count(letter))
            {
                return false;
            }

            seen.insert(letter);
        }

        return true;
    }

} // namespace isogram
