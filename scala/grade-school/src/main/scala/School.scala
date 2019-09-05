class School {
  type DB = Map[Int, Seq[String]]

  var database: DB = Map()

  def add(name: String, g: Int) = {
    var el: Seq[String] = Seq(name)
    if (database.contains(g)){
      el = database(g)
      el = el :+ name
    }
    database = database + (g -> el)
  }

  def db: DB = database

  def grade(g: Int): Seq[String] = {
    if (database.contains(g)){
      database(g)
    }
    else{
      Seq()
    }
  }

  def sorted: DB = {
    var toSort: DB = db
    var sorted: DB = Map()
    for (i <- toSort.keys.toSeq.sorted){
      if (toSort.contains(i)){
        var el: Seq[String] = toSort(i)
        el = el.sorted
        sorted = sorted + (i -> el)
      }
    }
    sorted
  }
}
