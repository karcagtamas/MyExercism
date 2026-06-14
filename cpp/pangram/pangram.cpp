#include "pangram.h"
#include <array>

namespace pangram
{

    bool is_pangram(const std::string &value)
    {
        const size_t size = 'z' - 'a' + 1;
        std::array<int, size> arr{};

        for (auto i : value)
        {
            int ch = tolower(i);

            if (ch >= 'a' && ch <= 'z')
            {
                arr[ch - 'a']++;
            }
        }

        for (auto i : arr)
        {
            if (i <= 0)
            {
                return false;
            }
        }

        return true;
    }

} // namespace pangram
