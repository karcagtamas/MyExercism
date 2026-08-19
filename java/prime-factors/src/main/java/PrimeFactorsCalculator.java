import java.util.ArrayList;
import java.util.List;

class PrimeFactorsCalculator {

    List<Long> calculatePrimeFactorsOf(long number) {
        var value = number;
        var factors = new ArrayList<Long>();

        while (value % 2L == 0L) {
            factors.add(2L);
            value /= 2L;
        }

        var n = 3L;

        while (n * n <= value) {
            while (value % n == 0L) {
                factors.add(n);
                value /= n;
            }

            n += 2;
        }

        if (value > 1) {
            factors.add(value);
        }

        return factors;
    }

}