import java.util.ArrayList;
import java.util.List;

class Sieve {
    private final int maxPrime;

    Sieve(int maxPrime) {
        this.maxPrime = maxPrime;
    }

    List<Integer> getPrimes() {
        final var primes = new ArrayList<Integer>();

        for (var i = 2; i <= maxPrime; i++) {
            if (i == 2) {
                primes.add(i);
                continue;
            }

            if (i % 2 == 0) {
                continue;
            }

            var hasDivisor = false;
            for (var x = 3; x <= Math.sqrt(i); x++) {
                if (i % x == 0) {
                    hasDivisor = true;
                    break;
                }
            }

            if (!hasDivisor) {
                primes.add(i);
            }
        }

        return primes;
    }
}
