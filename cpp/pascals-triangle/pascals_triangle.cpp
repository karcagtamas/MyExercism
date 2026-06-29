#include "pascals_triangle.h"

namespace pascals_triangle
{

    static int value(int i, int j, std::vector<std::vector<int>> &tri)
    {
        if (i == 0 && j == 0)
            return 1;

        if (i - 1 == 0)
            return 1;

        if (j == 0 || i == j)
            return 1;

        return tri[i - 1][j - 1] + tri[i - 1][j];
    }

    std::vector<std::vector<int>> generate_rows(int rows)
    {

        std::vector<std::vector<int>> result{};

        for (int i = 0; i < rows; i++)
        {

            std::vector<int> row{};
            for (int j = 0; j < i + 1; j++)
            {
                row.push_back(value(i, j, result));
            }
            result.push_back(row);
        }

        return result;
    }

} // namespace pascals_triangle
