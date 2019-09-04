class School {
  type DB = Map[Int, Seq[String]]

  var database: DB = Map()

  def add(name: String, g: Int) = {
    var el: Seq[String] = Seq(name)
    if (database.contains(g)){
      el = database(g)
      el :+ name
    }
    println(el)
    database + (g -> el)
  }

  def db: DB = database

  def grade(g: Int): Seq[String] = ???

  def sorted: DB = ???
}
