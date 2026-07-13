import java.util.Arrays;
import java.util.List;

class ResistorColorTrio {

    private static final List<String> COLORS = List.of("black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white");
    private static final List<String> UNITS = List.of("ohms", "kiloohms", "megaohms", "gigaohms", "teraohms", "petaohms", "exaohms");

    String label(String[] colors) {
        final var values = Arrays.stream(colors).map(COLORS::indexOf).limit(3).toList();

        int number = 0;
        for (int i = 0; i < 2; i++) {
            number += (int) (values.get(i) * Math.pow(10.0, 2 - i - 1));
        }
        int zeros = values.getLast();

        if (number % 10 == 0) {
            number /= 10;
            zeros++;
        }

        final var unit = UNITS.get(zeros / 3);
        number *= (int) Math.pow(10.0, zeros % 3);

        return "%d %s".formatted(number, unit);
    }
}
