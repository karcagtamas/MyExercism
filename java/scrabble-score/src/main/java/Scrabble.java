import java.util.*;

class Scrabble {

    private final String word;

    private static final List<LetterScores> LETTER_SCORES = Arrays.asList(
            new LetterScores(1, "AEIOULNRST"),
            new LetterScores(2, "DG"),
            new LetterScores(3, "BCMP"),
            new LetterScores(4, "FHVWY"),
            new LetterScores(5, "K"),
            new LetterScores(8, "JX"),
            new LetterScores(10, "QZ"));

    Scrabble(String word) {
        this.word = word.toUpperCase();
    }

    int getScore() {
        return this.word.chars()
                .map(this::scoreForLetter)
                .sum();
    }

    int scoreForLetter(int letter) {
        return LETTER_SCORES.stream().filter(scores -> scores.isContains((char)letter)).findFirst().orElse(new LetterScores(0, "")).getPoint();
    }

    private static class LetterScores {
        private final int point;
        private final String chars;

        public LetterScores(int point, String chars) {
            this.point = point;
            this.chars = chars;
        }

        public int getPoint() {
            return this.point;
        }

        public boolean isContains(Character character) {
            return chars.contains(character.toString());
        }
    }

}
