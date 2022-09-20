class Bob {
  // Put your code here

  String response(String sentence) {
    var trimmed = sentence.trim();

    if (trimmed.isEmpty) {
      return 'Fine. Be that way!';
    }

    bool isQuestion = trimmed[trimmed.length - 1] == '?';

    if (trimmed.toLowerCase().toUpperCase() == trimmed &&
        trimmed.contains(RegExp(r"[a-zA-Z]{1}"))) {
      if (isQuestion) {
        return 'Calm down, I know what I\'m doing!';
      }

      return 'Whoa, chill out!';
    }

    if (isQuestion) {
      return 'Sure.';
    }

    return 'Whatever.';
  }
}
