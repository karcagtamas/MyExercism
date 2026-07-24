import java.util.ArrayList;
import java.util.List;

class LargestSeriesProductCalculator {

    private final List<Integer> digits;

    LargestSeriesProductCalculator(String inputNumber) {
        final var digits = new ArrayList<Integer>();

        for (var i = 0; i < inputNumber.length(); i++) {
            if (!Character.isDigit(inputNumber.charAt(i))) {
                throw new IllegalArgumentException("String to search may only contain digits.");
            }

            digits.add(inputNumber.charAt(i) - '0');
        }

        this.digits = digits;
    }

    long calculateLargestProductForSeriesLength(int numberOfDigits) {
        if (numberOfDigits > digits.size()) {
            throw new IllegalArgumentException("Series length must be less than or equal to the length of the string to search.");
        }

        if (numberOfDigits == 0) return 1;

        long largest = 0;

        for (var i = 0; i <= digits.size() - numberOfDigits; i++) {
            long product = 1;

            for (var j = 0; j < numberOfDigits; j++) {
                product *= digits.get(i + j);
            }

            if (product > largest) {
                largest = product;
            }
        }

        return largest;
    }
}
