import java.util.stream.Collectors;

class RnaTranscription {

    String transcribe(String dnaStrand) {
        return dnaStrand.chars()
                .mapToObj(ch -> switch ((char) ch) {
                    case 'G' -> "C";
                    case 'C' -> "G";
                    case 'T' -> "A";
                    case 'A' -> "U";
                    default -> " ";
                })
                .collect(Collectors.joining());
    }

}
