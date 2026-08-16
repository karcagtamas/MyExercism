import java.util.List;

class TwelveDays {

    private static final List<String> days = List.of(
            "first",
            "second",
            "third",
            "fourth",
            "fifth",
            "sixth",
            "seventh",
            "eighth",
            "ninth",
            "tenth",
            "eleventh",
            "twelfth"
    );

    private static final List<String> gifts = List.of(
            "a Partridge in a Pear Tree",
            "two Turtle Doves",
            "three French Hens",
            "four Calling Birds",
            "five Gold Rings",
            "six Geese-a-Laying",
            "seven Swans-a-Swimming",
            "eight Maids-a-Milking",
            "nine Ladies Dancing",
            "ten Lords-a-Leaping",
            "eleven Pipers Piping",
            "twelve Drummers Drumming"
    );

    String verse(int verseNumber) {
        var sb = new StringBuilder();

        sb.append("On the %s day of Christmas my true love gave to me: ".formatted(days.get(verseNumber - 1)));

        for (var i = verseNumber - 1; i >= 0; i--) {
            if (i == 0 && verseNumber > 1) sb.append("and ");

            sb.append(gifts.get(i));

            if (i > 0) sb.append(", ");
        }

        sb.append('.');
        sb.append('\n');

        return sb.toString();
    }

    String verses(int startVerse, int endVerse) {
        var sb = new StringBuilder();

        for (int i = startVerse; i <= endVerse; i++) {
            sb.append(verse(i));

            if (i != endVerse) sb.append('\n');
        }

        return sb.toString();
    }

    String sing() {
        return verses(1, 12);
    }
}
