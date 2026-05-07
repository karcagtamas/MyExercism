public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var matrix = new int[size, size];

        var top = 0;
        var bottom = size - 1;
        var left = 0;
        var right = size - 1;

        var num = 1;

        while (top <= bottom && left <= right)
        {
            for (var col = left; col <= right; col++)
            {
                matrix[top, col] = num++;
            }
            top++;

            for (var row = top; row <= bottom; row++)
            {
                matrix[row, right] = num++;
            }
            right--;

            if (top <= bottom)
            {
                for (var col = right; col >= left; col--)
                {
                    matrix[bottom, col] = num++;
                }
                bottom--;
            }

            if (left <= right)
            {
                for (var row = bottom; row >= top; row--)
                {
                    matrix[row, left] = num++;
                }
                left++;
            }
        }

        return matrix;
    }
}
