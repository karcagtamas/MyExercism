object Hamming {
  def distance(left: String, right: String): Option[Int] = {
    var dist: Int = 0;
    if (left.length != right.length) {
      return None
    }
    for (i <- 0 to left.length() - 1) {

      if (left.charAt(i) != right.charAt(i)) {
        dist += 1;
      }
    }
    return Option(dist)
  }
}
