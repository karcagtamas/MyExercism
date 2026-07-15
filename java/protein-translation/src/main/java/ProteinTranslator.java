import java.util.*;

class ProteinTranslator {

    private static final Map<String, List<String>> PROTEIN_LIST = new HashMap<>() {{
        put("Methionine", List.of("AUG"));
        put("Phenylalanine", List.of("UUU", "UUC"));
        put("Leucine", List.of("UUA", "UUG"));
        put("Serine", List.of("UCU", "UCC", "UCA", "UCG"));
        put("Tyrosine", List.of("UAU", "UAC"));
        put("Cysteine", List.of("UGU", "UGC"));
        put("Tryptophan", List.of("UGG"));
        put("STOP", List.of("UAA", "UAG", "UGA"));
    }};

    List<String> translate(String rnaSequence) {
        final var result = new ArrayList<String>();

        for (int i = 0; i < rnaSequence.length(); i += 3) {
            if (i + 3 > rnaSequence.length()) {
                throw new IllegalArgumentException("Invalid codon");
            }

            final var codon = rnaSequence.substring(i, i + 3);

            final var prot = PROTEIN_LIST.entrySet().stream()
                    .filter(p -> p.getValue().contains(codon))
                    .map(Map.Entry::getKey)
                    .findFirst()
                    .orElseThrow(() -> new IllegalArgumentException("Invalid codon"));

            if (Objects.equals(prot, "STOP")) {
                break;
            }

            result.add(prot);
        }

        return result;
    }
}
