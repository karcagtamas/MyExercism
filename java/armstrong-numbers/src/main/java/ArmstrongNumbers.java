class ArmstrongNumbers {

    boolean isArmstrongNumber(int numberToCheck) {

        final var str = Integer.toString(numberToCheck);
        int sum = 0;

        for (int i = 0; i < str.length(); i++) {
            final var ch = str.charAt(i);

            sum += (int) Math.pow(ch - '0', str.length());
        }

        return sum == numberToCheck;
    }

}
