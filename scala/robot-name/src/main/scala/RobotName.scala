import scala.util.Random

class Robot {
  private var robotName: String = generateName

  def reset(): Unit = {
    robotName = ""
  }

  def name: String = {
    if (robotName.isEmpty) {
      robotName = generateName
    }
    robotName
  }

  private def generateName: String = {
    s"${genLetter}${genLetter}${genNum}${genNum}${genNum}".toUpperCase()
  }

  private def genNum: Character = {
    genChar("0123456789")
  }

  private def genLetter: Character = {
    genChar("abcdefghijklmopqrstxyz")
  }

  private def genChar(src: String): Character = {
    src.charAt((Random.nextFloat() * src.length).toInt)
  }
}