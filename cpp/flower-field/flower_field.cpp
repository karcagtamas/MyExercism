#include "flower_field.h"

namespace flower_field
{

    static int calc(int i, int j, const std::vector<std::string> &field, int x, int y)
    {
        int cnt = 0;

        for (int r = std::max(0, i - 1); r <= std::min(x - 1, i + 1); r++)
        {
            for (int c = std::max(0, j - 1); c <= std::min(y - 1, j + 1); c++)
            {
                if (field[r][c] == '*')
                {
                    cnt++;
                }
            }
        }

        return cnt;
    }

    std::vector<std::string> annotate(const std::vector<std::string> &field)
    {
        int x = field.size();
        int y = (x > 0) ? field[0].size() : 0;

        std::vector<std::string> result{};

        for (int i = 0; i < x; i++)
        {
            std::string s{};

            for (int j = 0; j < y; j++)
            {
                if (field[i][j] == '*')
                {
                    s += '*';
                }
                else
                {
                    int cnt = calc(i, j, field, x, y);

                    s += (cnt == 0) ? " " : std::to_string(cnt);
                }
            }

            result.push_back(s);
        }

        return result;
    }

} // namespace flower_field
