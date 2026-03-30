import kotlin.math.floor
import kotlin.random.Random

class DndCharacter {

    val strength: Int = ability()
    val dexterity: Int = ability()
    val constitution: Int = ability()
    val intelligence: Int = ability()
    val wisdom: Int = ability()
    val charisma: Int = ability()
    val hitpoints: Int = 10 + modifier(constitution)

    companion object {

        fun ability(): Int {
            return (0..3)
                .map { Random.nextInt(1, 6) }
                .sorted()
                .take(3)
                .sum()
        }

        fun modifier(score: Int): Int {
            return floor((score - 10) / 2.0).toInt()
        }
    }

}
