class NaturalNumber {
    private final int number;
    private final Classification classification;

    NaturalNumber(int number) {
        this.number = number;

        if (number <= 0) {
            throw new IllegalArgumentException("You must supply a natural number (positive integer)");
        }

        int divisorSum = 1;

        for (int i = 2; i * i <= number; i++) {
            if (number % i == 0) {
                divisorSum += i;

                if (i != number / i) {
                    divisorSum += number / i;
                }
            }
        }

        if (number == 1) {
            divisorSum = 0;
        }

        if (divisorSum < number) {
            this.classification = Classification.DEFICIENT;
        } else if (divisorSum > number) {
            this.classification = Classification.ABUNDANT;
        } else {
            this.classification = Classification.PERFECT;
        }
    }

    Classification getClassification() {
        return classification;
    }
}
