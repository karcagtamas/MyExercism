#include "etl.h"
#include <string>

namespace etl
{

    std::map<char, int> transform(std::map<int, std::vector<char>> old)
    {

        std::map<char, int> result{};

        for (auto [k, v] : old)
        {
            for (auto t : v)
            {

                t = static_cast<char>(std::tolower(static_cast<unsigned char>(t)));
                result.emplace(t, k);
            }
        }

        return result;
    }

} // namespace etl
