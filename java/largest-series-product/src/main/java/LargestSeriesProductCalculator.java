class LargestSeriesProductCalculator {

    private final String inputNumber;

    LargestSeriesProductCalculator(String inputNumber) {
        for (var i = 0; i < inputNumber.length(); i++) {
            if (!Character.isDigit(inputNumber.charAt(i))) {
                throw new IllegalArgumentException("String to search may only contain digits.");
            }
        }

        this.inputNumber = inputNumber;
    }

    long calculateLargestProductForSeriesLength(int numberOfDigits) {
        if (numberOfDigits > inputNumber.length()) {
            throw new IllegalArgumentException("Series length must be less than or equal to the length of the string to search.");
        }

        if (numberOfDigits == 0) return 1;

        long largest = 0;

        for (var i = 0; i <= inputNumber.length() - numberOfDigits; i++) {
            long product = 1;

            for (var j = 0; j < numberOfDigits; j++) {
                product *= inputNumber.charAt(i + j) - '0';
            }

            if (product > largest) {
                largest = product;
            }
        }

        return largest;
    }
}
