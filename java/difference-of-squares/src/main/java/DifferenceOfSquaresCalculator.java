import java.util.stream.Collectors;
import java.util.stream.IntStream;

class DifferenceOfSquaresCalculator {

    int computeSquareOfSumTo(int input) {
        return (int)Math.pow(IntStream.rangeClosed(1, input).boxed().reduce(0, Integer::sum), 2);
    }

    int computeSumOfSquaresTo(int input) {
        return IntStream.rangeClosed(1, input).boxed().reduce(0, (a, b) -> a + (int)Math.pow(b, 2));
    }

    int computeDifferenceOfSquares(int input) {
        return computeSquareOfSumTo(input) - computeSumOfSquaresTo(input);
    }

}
