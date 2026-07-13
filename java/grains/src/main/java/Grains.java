import java.math.BigInteger;
import java.util.stream.IntStream;

class Grains {

    BigInteger grainsOnSquare(final int square) {
        if (square <= 0 || square > 64) {
            throw new IllegalArgumentException("square must be between 1 and 64");
        }

        var sum = BigInteger.ONE;

        for (int i = 0; i < square - 1; i++) {
            sum = sum.multiply(BigInteger.TWO);
        }

        return sum;
    }

    BigInteger grainsOnBoard() {
        return IntStream.range(1, 65)
                .mapToObj(this::grainsOnSquare)
                .reduce(BigInteger.ZERO, BigInteger::add);
    }

}
