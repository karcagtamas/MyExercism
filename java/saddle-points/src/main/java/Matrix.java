import java.util.HashSet;
import java.util.List;
import java.util.Set;

class Matrix {

    private final List<List<Integer>> values;

    Matrix(List<List<Integer>> values) {
        this.values = values;
    }

    Set<MatrixCoordinate> getSaddlePoints() {
        final var saddlePoints = new HashSet<MatrixCoordinate>();

        for (var i = 0; i < values.size(); i++) {
            for (var j = 0; j < values.get(i).size(); j++) {
                final var value = values.get(i).get(j);
                if (isMaxInRow(value, i) && isMinInCol(value, j)) {
                    saddlePoints.add(new MatrixCoordinate(i + 1, j + 1));
                }
            }
        }

        return saddlePoints;
    }

    private boolean isMaxInRow(int value, int rowIndex) {
        for (var j = 0; j < values.get(rowIndex).size(); j++) {
            if (values.get(rowIndex).get(j) > value) {
                return false;
            }
        }

        return true;
    }

    private boolean isMinInCol(int value, int colIndex) {
        for (List<Integer> integers : values) {
            if (integers.get(colIndex) < value) {
                return false;
            }
        }

        return true;
    }
}
