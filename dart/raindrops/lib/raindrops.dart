class Raindrops {
  Map<int, String> _maps = {
    3: "Pling",
    5: "Plang",
    7: "Plong",
  };

  String convert(int number) {
    final factors =
        [3, 5, 7].where((element) => number % element == 0).toList();

    if (factors.isEmpty) {
      return number.toString();
    }

    String result = "";

    _maps.forEach((key, value) {
      if (factors.contains(key)) {
        result += value;
      }
    });

    return result;
  }
}
