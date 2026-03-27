class Allergies(score: Int) {

    val allergies = mutableListOf<Allergen>()

    init {
        Allergen.values()
            .forEach { allergen ->
                if (score and allergen.score != 0) {
                    allergies.add(allergen)
                }
            }
    }

    fun getList(): List<Allergen> = allergies.toList()

    fun isAllergicTo(allergen: Allergen): Boolean = allergies.contains(allergen)
}
