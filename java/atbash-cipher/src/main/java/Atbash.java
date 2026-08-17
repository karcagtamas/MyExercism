import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

class Atbash {

    String encode(String input) {
        String translated = translate(input);
        List<String> chunks = new ArrayList<>();

        for (int i = 0; i < translated.length(); i += 5) {
            chunks.add(translated.substring(i, Math.min(i + 5, translated.length())));
        }

        return String.join(" ", chunks);
    }

    String decode(String input) {
        return translate(input);
    }

    private String translate(String s) {
        return s.toLowerCase().chars()
                .filter(Character::isLetterOrDigit)
                .map(c -> {
                    return Character.isLetter(c)
                            ? ('z' - (c - 'a'))
                            : c;
                })
                .mapToObj(Character::toString)
                .collect(Collectors.joining(""));
    }

}
