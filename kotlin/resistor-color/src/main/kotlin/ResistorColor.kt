object ResistorColor {

    enum class Color {
        BLACK,
        BROWN,
        RED,
        ORANGE,
        YELLOW,
        GREEN,
        BLUE,
        VIOLET,
        GREY,
        WHITE,
    }

    fun colorCode(input: String): Int {
        return Color.valueOf(input.uppercase()).ordinal
    }

    fun colors(): List<String> {
        return Color.values().map { it.name.lowercase() }
    }

}
