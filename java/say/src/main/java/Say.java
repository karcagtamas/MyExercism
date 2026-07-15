import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Say {

    private static final List<String> small = List.of(
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
    );
    private static final List<String> tens = List.of("", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety");
    private static final List<String> scales = List.of("", "thousand", "million", "billion");

    public String say(long number) {
        if (number < 0 || number > 999_999_999_999L) {
            throw new IllegalArgumentException("");
        }

        if (number == 0) {
            return "zero";
        }

        var num = number;
        var scaleIndex = 0;
        final var parts = new ArrayList<String>();

        while (num > 0) {
            final var chunk = (int) (num % 1000);

            if (chunk != 0) {
                final var chunkText = sayUnder1000(chunk);
                final var scale = scales.get(scaleIndex);

                parts.add(scale.isEmpty() ? chunkText : "%s %s".formatted(chunkText, scale));
            }

            num /= 1000;
            scaleIndex++;
        }

        return String.join(" ", parts.reversed());
    }

    private String sayUnder1000(int num) {
        final var parts = new ArrayList<String>();

        final var hundreds = num / 100;
        final var remainder = num % 100;

        if (hundreds > 0) {
            parts.add(small.get(hundreds) + " hundred");
        }

        if (remainder > 0) {
            if (remainder < 20) {
                parts.add(small.get(remainder));
            } else if (remainder % 10 == 0) {
                parts.add(tens.get(remainder / 10));
            } else {
                parts.add("%s-%s".formatted(tens.get(remainder / 10), small.get(remainder % 10)));
            }
        }

        return String.join(" ", parts);
    }
}
