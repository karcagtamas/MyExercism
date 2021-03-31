import scala.collection.mutable

object Etl {
  def transform(map: Map[Int, Seq[String]]): Map[String, Int] = {
    val cMap = FlatMap[String, Int]()
    for (value: (Int, Seq[String]) <- map) {
      for (subValue: String <- value._2) {
        cMap += (subValue.toLowerCase -> value._1)
      }
    }
    cMap.toMap
  }
}