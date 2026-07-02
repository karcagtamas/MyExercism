#include "diamond.h"
#include <algorithm>

namespace diamond
{

    std::vector<std::string> rows(char target)
    {
        int side = target - 'A' + 1;
        int rows = side * 2 - 1;

        std::vector<std::string> result{};

        for (int r = 0; r < rows; r++)
        {
            int d = std::min(r, rows - 1 - r);
            int c = (d + 'A');

            int outer_spaces = side - d - 1;

            std::string row{};

            row.append(outer_spaces, ' ');
            row += c;

            if (d > 0)
            {
                row.append(2 * d - 1, ' ');
                row += c;
            }

            row.append(outer_spaces, ' ');

            result.push_back(row);
        }

        return result;
    }

} // namespace diamond
