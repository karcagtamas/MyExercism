class PrimeCalculator {

    int nth(int nth) {
        if (nth <= 0) throw new IllegalArgumentException("There is no zeroth prime");

        var x = 2;
        var c = 1;

        while (c < nth) {
            x++;

            if (isPrime(x)) {
                c++;
            }
        }

        return x;
    }

    private static boolean isPrime(int n) {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        for (var i = 3; i <= Math.sqrt(n); i += 2) {
            if (n % i == 0) return false;
        }

        return true;
    }

}
