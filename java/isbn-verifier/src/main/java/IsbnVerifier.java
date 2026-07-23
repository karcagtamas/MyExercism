class IsbnVerifier {

    boolean isValid(String stringToVerify) {
        int sum = 0;
        int count = 0;

        for (var i = 0; i < stringToVerify.length(); i++) {
            final var ch = stringToVerify.charAt(i);

            if (ch == '-') continue;

            count++;
            int value;

            if (Character.isDigit(ch)) {
                value = ch - '0';
            } else if (ch == 'X' && count == 10) {
                value = 10;
            } else {
                return false;
            }

            sum += value * (11 - count);
        }

        return count == 10 && sum % 11 == 0;
    }

}
