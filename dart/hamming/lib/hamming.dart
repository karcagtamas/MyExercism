class Hamming {
  // Put your code here

  int distance(String left, String right) {
    if ((left.length == 0 || right.length == 0) &&
        left.length + right.length != 0) {
      throw ArgumentError('no strand must be empty');
    }

    if (left.length != right.length) {
      throw ArgumentError('left and right strands must be of equal length');
    }

    int res = 0;

    for (var i = 0; i < left.length; i++) {
      if (left[i] != right[i]) {
        res++;
      }
    }

    return res;
  }
}
