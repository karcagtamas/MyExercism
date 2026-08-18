class GameOfLife {
    public int[][] tick(int[][] matrix) {
        if (matrix.length == 0 || matrix[0].length == 0) {
            return new int[][]{};
        }

        int rows = matrix.length;
        int cols = matrix[0].length;

        var next = new int[rows][cols];

        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                var neighbours = countNeighbours(matrix, row, col);

                next[row][col] = matrix[row][col] == 1
                        ? neighbours == 2 || neighbours == 3
                        ? 1
                        : 0
                        : neighbours == 3
                        ? 1
                        : 0;
            }
        }

        return next;
    }

    private int countNeighbours(int[][] matrix, int row, int col) {
        int rows = matrix.length;
        int cols = matrix[0].length;
        int count = 0;

        for (int dr = -1; dr <= 1; dr++) {
            for (int dc = -1; dc <= 1; dc++) {
                if (dr == 0 && dc == 0) continue;

                int r = row + dr;
                int c = col + dc;

                if (r >= 0 && r < rows && c >= 0 && c < cols) {
                    count += matrix[r][c];
                }
            }
        }

        return count;
    }
}
