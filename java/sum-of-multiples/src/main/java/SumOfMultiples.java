class SumOfMultiples {

    private int sum;

    SumOfMultiples(int number, int[] set) {
        int sum = 0;

        for (int i = 1; i < number; i++) {

            for (int x = 0; x < set.length; x++) {
                if (set[x] != 0 && i % set[x] == 0) {
                    sum += i;
                    break;
                }
            }
        }

        this.sum = sum;
    }

    int getSum() {
        return sum;
    }

}
