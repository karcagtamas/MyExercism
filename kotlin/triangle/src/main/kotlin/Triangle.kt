class Triangle<out T : Number>(val a: T, val b: T, val c: T) {

    init {
        require(a.toDouble() + b.toDouble() > c.toDouble())
        require(a.toDouble() + c.toDouble() > b.toDouble())
        require(b.toDouble() + c.toDouble() > a.toDouble())
    }

    val isEquilateral: Boolean = a == b && b == c
    val isIsosceles: Boolean = a == b || b == c || c == a
    val isScalene: Boolean = a != b && b != c && c != a
}
