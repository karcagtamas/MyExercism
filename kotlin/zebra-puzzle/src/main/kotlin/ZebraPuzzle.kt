import kotlin.math.abs

class ZebraPuzzle() {

    private val solution: List<House>

    init {
        solution = solve()
    }

    fun drinksWater(): String = solution.first { it.drink == "water" }.nationality

    fun ownsZebra(): String = solution.first { it.pet == "zebra" }.nationality

    private fun solve(): List<House> {
        val positions = listOf(1, 2, 3, 4, 5)

        fun <T> permutations(list: List<T>): List<List<T>> {
            if (list.isEmpty()) return listOf(emptyList())

            return list.flatMap { item ->
                permutations(list - item).map {
                    listOf(item) + it
                }
            }
        }

        val colors = permutations(listOf("red", "green", "ivory", "yellow", "blue"))
        val nationalities = permutations(listOf("Englishman", "Spaniard", "Ukrainian", "Norwegian", "Japanese"))
        val pets = permutations(listOf("dog", "snails", "fox", "horse", "zebra"))
        val drinks = permutations(listOf("coffee", "tea", "milk", "orange juice", "water"))
        val hobbies = permutations(listOf("dancing", "painter", "reading", "football", "chess"))

        for (color in colors) {
            val green = color.indexOf("green")
            val ivory = color.indexOf("ivory")

            if (green != ivory + 1) continue

            for (nation in nationalities) {
                if (nation[0] != "Norwegian") continue

                if (nation.indexOf("Englishman") != color.indexOf("red")) continue

                if (abs(nation.indexOf("Norwegian") - color.indexOf("blue")) != 1) continue

                for (drink in drinks) {
                    if (drink[2] != "milk") continue

                    if (drink[color.indexOf("green")] != "coffee") continue

                    if (drink[nation.indexOf("Ukrainian")] != "tea") continue

                    for (hobby in hobbies) {
                        if (hobby[color.indexOf("yellow")] != "painter") continue

                        if (hobby[nation.indexOf("Japanese")] != "chess") continue

                        if (drink[hobby.indexOf("football")] != "orange juice") continue

                        for (pet in pets) {
                            if (pet[nation.indexOf("Spaniard")] != "dog") continue

                            if (hobby[pet.indexOf("snails")] != "dancing") continue

                            if (abs(hobby.indexOf("reading") - pet.indexOf("fox")) != 1) continue

                            if (abs(hobby.indexOf("painter") - pet.indexOf("horse")) != 1) continue

                            return positions.map { i ->
                                House(
                                    position = i,
                                    color = color[i - 1],
                                    nationality = nation[i - 1],
                                    pet = pet[i - 1],
                                    drink = drink[i - 1],
                                    hobby = hobby[i - 1],
                                )
                            }
                        }
                    }
                }
            }
        }

        error("No solution found")
    }

    data class House(
        val position: Int,
        val color: String,
        val nationality: String,
        val pet: String,
        val drink: String,
        val hobby: String,
    )

}
