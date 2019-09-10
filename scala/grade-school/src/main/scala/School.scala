import scala.collection.immutable.SortedMap
class School {
  type DB = Map[Int, Seq[String]]

  private var database: DB = Map()

  def add(name: String, g: Int) = {
    var el: Seq[String] = database.getOrElse(g, Seq())
    database = database + (g -> (el :+ name))
  }

  def db: DB = database

  def grade(g: Int): Seq[String] = {
    database.getOrElse(g, Seq())
  }

  def sorted: DB = {
    var toSort: DB = db
    var sorted = SortedMap[Int, Seq[String]]() ++ toSort
    sorted = sorted.mapValues(x => x.sorted)
    sorted
  }
}
