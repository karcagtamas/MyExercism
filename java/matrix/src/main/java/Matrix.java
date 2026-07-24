import java.util.Arrays;

class Matrix {

    private final int[][] m;

    Matrix(String matrixAsString) {
        this.m = Arrays.stream(matrixAsString.split("\n"))
                .map(row -> Arrays.stream(row.split(" "))
                        .mapToInt(Integer::parseInt)
                        .toArray())
                .toArray(int[][]::new);
    }

    int[] getRow(int rowNumber) {
        return m[rowNumber - 1];
    }

    int[] getColumn(int columnNumber) {
        return Arrays.stream(m)
                .mapToInt(row -> row[columnNumber - 1])
                .toArray();
    }
}
