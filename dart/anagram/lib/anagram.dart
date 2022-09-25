import 'package:collection/collection.dart';

class Anagram {
  List<String> findAnagrams(String word, List<String> possibilties) {
    final original = _split(word);

    return possibilties
        .where((element) => element.toLowerCase() != word.toLowerCase())
        .where(
          (element) => MapEquality<String, int>().equals(
            _split(element),
            original,
          ),
        )
        .toList();
  }

  Map<String, int> _split(String word) {
    return word.toLowerCase().split("").fold({}, (previousValue, element) {
      previousValue.update(
        element,
        (value) => value + 1,
        ifAbsent: () => 1,
      );

      return previousValue;
    });
  }
}
