import java.util.ArrayList;
import java.util.List;

class DiamondPrinter {

    List<String> printToList(char a) {
        final var side = a - 'A' + 1;
        final var rows = side * 2 - 1;

        final var result = new ArrayList<String>();

        for (var r = 0; r < rows; r++) {
            final var d = Math.min(r, rows - 1 - r);
            final var c = (char) (d + 'A');

            final var outerSpaces = side - d - 1;

            final var sb = new StringBuilder();

            sb.repeat(' ', outerSpaces);
            sb.append(c);

            if (d > 0) {
                sb.repeat(' ', 2 * d - 1);
                sb.append(c);
            }

            sb.repeat(' ', outerSpaces);
            result.add(sb.toString());
        }

        return result;
    }

}
