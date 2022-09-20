class WordCount {
  // Put your code here

  Map<String, int> countWords(String text) {
    final result = Map<String, int>();

    text
        .replaceAll(',', ' ')
        .replaceAll(RegExp(r"[!|&|@|$|%|^|&|:|.]{1}"), '')
        .split(RegExp(r"\s+"))
        .where((element) => element != '')
        .map((e) {
      if (e[0] == "'" && e[e.length - 1] == "'") {
        return e.replaceAll("'", "");
      }
      return e;
    }).forEach((element) {
      var el = element.toLowerCase();
      if (result.containsKey(el)) {
        result.update(el, (value) => value + 1);
      } else {
        result.putIfAbsent(el, () => 1);
      }
    });

    return result;
  }
}
