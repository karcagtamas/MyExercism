object Bob {
  private val SMALL_LETTERS: String = "qwertzuiopasdfghjklyxcvbnm";
  private val LETTERS: String = "qwertzuiopasdfghjklyxcvbnmQWERTZUIOPASDFGHJKLYXCVBNM"

  def response(statement: String): String = {
    if (isSilence(statement)){
      return "Fine. Be that way!"
    }
    if (isShoutingQuestion(statement)){
      return "Calm down, I know what I'm doing!"
    }
    if (isShouting(statement)){
      return "Whoa, chill out!"
    }
    if (isQuestion(statement)){
      return "Sure."
    }
    return "Whatever."
  }

  def isShouting(statement: String): Boolean = {
    var wasLetter: Boolean = false;
    for (letter <- statement){
      if (SMALL_LETTERS.contains(letter)){
        return false
      }
      if (LETTERS.contains(letter)){
        wasLetter = true
      }
    }
    return wasLetter
  }

  def isQuestion(statement: String): Boolean = {
    return statement.trim().endsWith("?")
  }

  def isShoutingQuestion(statement: String): Boolean = {
    return isQuestion(statement) && isShouting(statement)
  }

  def isSilence(statement: String): Boolean = {
    return statement.trim().isEmpty()
  }
}
