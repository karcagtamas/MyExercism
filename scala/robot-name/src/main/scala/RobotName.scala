import scala.util.Random

class Robot {
  var robotName: String = generateName

  def genNum: Character = {
    genChar("0123456789")
  }

  def genLetter: Character = {
    genChar("abcdefghijklmopqrstxyz")
  }

  def genChar(src: String): Character = {
    src.charAt((Random.nextFloat() * src.length).toInt)
  }

  def reset(): Unit = {
    robotName = ""
  }

  def name: String = {
    if (robotName.isEmpty) {
      robotName = generateName
    }
    robotName
  }

  def generateName: String = {
    s"${genLetter}${genLetter}${genNum}${genNum}${genNum}".toUpperCase()
  }
}