import java.util.Arrays;
import java.util.Collections;
import java.util.List;

class ResistorColorDuo {
    private static final List<String> COLORS = List.of(
            "black",
            "brown",
            "red",
            "orange",
            "yellow",
            "green",
            "blue",
            "violet",
            "grey",
            "white"
    );


    int value(String[] colors) {
        final var colorIndexes = Arrays.stream(colors)
                .limit(2)
                .map(COLORS::indexOf)
                .toList();

        int result = 0;

        for (int i = 0; i < colorIndexes.size(); i++) {
            result += (int) (colorIndexes.get(i) * Math.pow(10.0, colorIndexes.size() - i - 1));
        }

        return result;
    }
}
