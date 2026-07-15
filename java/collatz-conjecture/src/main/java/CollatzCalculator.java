class CollatzCalculator {

    int computeStepCount(int start) {
        if (start <= 0) {
            throw new IllegalArgumentException("Only positive integers are allowed");
        }

        int number = start;
        int steps = 0;

        while (number != 1) {
            number = number % 2 == 0 ? number / 2 : number * 3 + 1;
            steps++;
        }

        return steps;
    }

}
