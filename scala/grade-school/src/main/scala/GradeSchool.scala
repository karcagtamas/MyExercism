class School {
  type DB = Map[Int, Seq[String]]

  private var database: DB = Map()

  def add(name: String, g: Int): Unit = {
    database = database + (g -> (grade(g) :+ name))
  }

  def db: DB = database

  def grade(g: Int): Seq[String] = database.getOrElse(g, Seq())

  def sorted: DB =
    database.toSeq
      .sortBy(_._1)
      .map { case (g, students) =>
        g -> students.sorted
      }
      .toMap
}

