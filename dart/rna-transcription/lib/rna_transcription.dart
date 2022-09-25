class RnaTranscription {
  final Map<String, String> _mappings = {
    'G': 'C',
    'C': 'G',
    'T': 'A',
    'A': 'U',
  };

  String toRna(String dna) => dna.split("").map((e) => _mappings[e]).join("");
}
