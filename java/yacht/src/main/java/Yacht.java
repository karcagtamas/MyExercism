import java.util.Arrays;

class Yacht {

    private final int[] dice;
    private final YachtCategory yachtCategory;
    private final int[] counts = new int[7];
    private final int sum;
    private final boolean fullHouse;

    Yacht(int[] dice, YachtCategory yachtCategory) {
        this.dice = dice;
        this.yachtCategory = yachtCategory;

        var sum = 0;

        for (var d : dice) {
            counts[d]++;
            sum += d;
        }

        this.sum = sum;

        this.fullHouse = containsFullHouse();
    }

    int score() {
        return switch (yachtCategory) {
            case YACHT -> Arrays.stream(counts).anyMatch(x -> x == 5) ? 50 : 0;
            case ONES -> counts[1];
            case TWOS -> counts[2] * 2;
            case THREES -> counts[3] * 3;
            case FOURS -> counts[4] * 4;
            case FIVES -> counts[5] * 5;
            case SIXES -> counts[6] * 6;
            case FULL_HOUSE -> this.fullHouse ? sum : 0;
            case FOUR_OF_A_KIND -> fourOfAKind();
            case LITTLE_STRAIGHT -> countsMatches(1, 2, 3, 4, 5) ? 30 : 0;
            case BIG_STRAIGHT -> countsMatches(2, 3, 4, 5, 6) ? 30 : 0;
            case CHOICE -> sum;
        };
    }

    private boolean containsFullHouse() {
        var has3 = false;
        var has2 = false;

        for (var c : counts) {
            if (c == 3) has3 = true;
            if (c == 2) has2 = true;
        }

        return has3 && has2;
    }

    private int fourOfAKind() {
        var max = 0;

        for (var i = 6; i >= 1; i--) {
            if (counts[i] >= 4 && i * 4 >= max) {
                max = i * 4;
            }
        }

        return max;
    }

    private boolean countsMatches(int... faces) {
        for (var f : faces) {
            if (counts[f] != 1) return false;
        }

        return true;
    }

}
