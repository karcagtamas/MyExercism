import java.util.HashMap;
import java.util.Map;

class NucleotideCounter {

    private final String sequence;
    private final Map<Character, Integer> elements;

    NucleotideCounter(String sequence) {
        this.sequence = sequence;

        final var elements = new HashMap<>(Map.of('A', 0, 'C', 0, 'G', 0, 'T', 0));

        for (var e : sequence.toCharArray()) {
            if (!elements.containsKey(e)) {
                throw new IllegalArgumentException();
            }

            elements.put(e, elements.get(e) + 1);
        }

        this.elements = elements;
    }

    Map<Character, Integer> nucleotideCounts() {
        return elements;
    }

}