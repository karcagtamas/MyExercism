import java.util.stream.Collectors;

class RotationalCipher {

    private final int shiftKey;

    RotationalCipher(int shiftKey) {
        this.shiftKey = shiftKey;
    }

    String rotate(String data) {
        return data.chars().map(c -> rotate((char) c))
                .mapToObj(c -> (char) c)
                .map(Object::toString)
                .collect(Collectors.joining(""));
    }

    private char rotate(char character) {
        if (character >= 'a' && character <= 'z') {
            return (char) (((character - 'a' + shiftKey) % 26) + 'a');
        } else if (character >= 'A' && character <= 'Z') {
            return (char) (((character - 'A' + shiftKey) % 26) + 'A');
        }

        return character;
    }

}
