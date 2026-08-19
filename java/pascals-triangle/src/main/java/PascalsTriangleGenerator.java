class PascalsTriangleGenerator {

    int[][] generateTriangle(int rows) {
        final var result = new int[rows][];

        for (var i = 0; i < rows; i++) {
            result[i] = new int[i + 1];
            for (var j = 0; j <= i; j++) {
                if (j == 0 || j == i) {
                    result[i][j] = 1;
                } else {
                    result[i][j] = result[i - 1][j] + result[i - 1][j - 1];
                }
            }
        }

        return result;
    }

}