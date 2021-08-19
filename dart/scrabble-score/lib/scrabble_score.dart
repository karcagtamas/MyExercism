// Put your code here
Map<String, int> scores = {
  'AEIOULNRST': 1,
  'DG': 2,
  'BCMP': 3,
  'FHVWY': 4,
  'K': 5,
  'JX': 8,
  'QZ': 10
};

int score(String text) {
  int sum = 0;

  text.toUpperCase().split("").forEach((element) {
    sum += getLetterScore(element);
  });

  return sum;
}

int getLetterScore(String letter) {
  String key = scores.keys.firstWhere((element) => element.contains(letter));
  return scores[key];
}