class LuhnValidator {

    boolean isValid(String candidate) {

        var sum = 0;
        var count = 0;
        var dbl = false;

        for (var i = candidate.length() - 1; i >= 0; i--) {
            var ch = candidate.charAt(i);

            if (ch == ' ') continue;
            if (!Character.isDigit(ch)) return false;

            var digit = ch - '0';

            if (dbl) {
                digit *= 2;
                if (digit > 9) digit -= 9;
            }

            sum += digit;
            dbl = !dbl;
            count++;
        }

        return count > 1 && sum % 10 == 0;
    }

}
