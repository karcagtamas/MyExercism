import java.util.Arrays;
import java.util.stream.Collectors;

class PhoneNumber {

    private static final String COUNTRY_CODE = "1";

    private final String original;
    private final String number;

    PhoneNumber(String numberString) {
        this.original = numberString;
        StringBuilder digitBuilder = new StringBuilder();
        for (char c : numberString.toCharArray()) {
            if (Character.isDigit(c)) {
                digitBuilder.append(c);
            } else if (Character.isLetter(c)) {
                throw new IllegalArgumentException("letters not permitted");
            } else {
                if (c == ' ' || c == '-' || c == '(' || c == ')' || c == '.' || c == '+') {
                    continue;
                }
                throw new IllegalArgumentException("punctuations not permitted");
            }
        }
        String digits = digitBuilder.toString();

        if (digits.length() > 10) {
            if (digits.length() > 11) {
                throw new IllegalArgumentException("must not be greater than 11 digits");
            }

            var countryCode = digits.substring(0, digits.length() - 10);
            digits = digits.substring(digitBuilder.length() - 10);

            if (!countryCode.equals(COUNTRY_CODE)) {
                throw new IllegalArgumentException("11 digits must start with 1");
            }
        } else {
            if (digits.length() < 10) {
                throw new IllegalArgumentException("must not be fewer than 10 digits");
            }
        }

        var areaCode = digits.substring(0, 3);
        if (areaCode.startsWith("0")) {
            throw new IllegalArgumentException("area code cannot start with zero");
        }

        if (areaCode.startsWith("1")) {
            throw new IllegalArgumentException("area code cannot start with one");
        }

        var exchangeCode = digits.substring(3);
        if (exchangeCode.startsWith("0")) {
            throw new IllegalArgumentException("exchange code cannot start with zero");
        }

        if (exchangeCode.startsWith("1")) {
            throw new IllegalArgumentException("exchange code cannot start with one");
        }

        this.number = digits;
    }

    String getNumber() {
        return number;
    }
}