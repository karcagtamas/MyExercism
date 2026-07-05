#include "spiral_matrix.h"

namespace spiral_matrix
{

    std::vector<std::vector<uint32_t>> spiral_matrix(uint32_t size)
    {
        std::vector<std::vector<uint32_t>> matrix(
            size,
            std::vector<uint32_t>(size, 0));

        int top = 0;
        int bottom = static_cast<int>(size) - 1;
        int left = 0;
        int right = static_cast<int>(size) - 1;

        uint32_t num = 1;

        while (top <= bottom && left <= right)
        {
            for (int col = left; col <= right; col++)
            {
                matrix[top][col] = num++;
            }
            top++;

            for (int row = top; row <= bottom; row++)
            {
                matrix[row][right] = num++;
            }
            right--;

            if (top <= bottom)
            {
                for (int col = right; col >= left; col--)
                {
                    matrix[bottom][col] = num++;
                }
                bottom--;
            }

            if (left <= right)
            {
                for (int row = bottom; row >= top; row--)
                {
                    matrix[row][left] = num++;
                }
                left++;
            }
        }

        return matrix;
    }

} // namespace spiral_matrix
