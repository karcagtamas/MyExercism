object Hamming {
  def distance(left: String, right: String): Option[Int] = {
    if (left.length != right.length) {
      return None
    }
    Option(left.zip(right).count(x => !x._1.equals(x._2)))
  }
}
