import java.util.*;

class Scrabble {

    private final String word;

    private static final List<Point> POINTS = Arrays.asList(
            new Point(1, "AEIOULNRST"),
            new Point(2, "DG"),
            new Point(3, "BCMP"),
            new Point(4, "FHVWY"),
            new Point(5, "K"),
            new Point(8, "JX"),
            new Point(10, "QZ"));

    Scrabble(String word) {
        this.word = word.toUpperCase();
    }

    int getScore() {
        int score = 0;
        for (int i = 0; i < this.word.length(); i++) {
            char current = this.word.charAt(i);
            score += POINTS.stream().filter(x -> x.isContains(current)).findFirst().orElse(new Point(0, "")).getPoint();
        }
        return score;
    }

}
