class Darts {
    int score(double xOfDart, double yOfDart) {

        final var fromO = Math.sqrt(Math.pow(xOfDart, 2) + Math.pow(yOfDart, 2));

        if (fromO > 10) {
            return 0;
        }

        if (fromO > 5) {
            return 1;
        }

        if (fromO > 1) {
            return 5;
        }

        return 10;
    }
}
