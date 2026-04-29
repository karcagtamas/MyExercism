fun <T> List<T>.customAppend(list: List<T>): List<T> {
    val result = mutableListOf<T>()

    for (item in this) {
        result.add(item)
    }

    for (item in list) {
        result.add(item)
    }

    return result
}

fun List<Any>.customConcat(): List<Any> {
    val result = mutableListOf<Any>()

    for (item in this) {
        if (item is List<*>) {
            @Suppress("UNCHECKED_CAST")
            result.addAll((item as List<Any>).customConcat())
        } else {
            result.add(item)
        }
    }

    return result
}

fun <T> List<T>.customFilter(predicate: (T) -> Boolean): List<T> {
    val result = mutableListOf<T>()

    for (item in this) {
        if (predicate(item)) {
            result.add(item)
        }
    }

    return result
}

val List<Any>.customSize: Int get() = size

fun <T, U> List<T>.customMap(transform: (T) -> U): List<U> {
    val result = mutableListOf<U>()

    for (item in this) {
        result.add(transform(item))
    }

    return result
}

fun <T, U> List<T>.customFoldLeft(initial: U, f: (U, T) -> U): U {
    var acc = initial

    for (item in this) {
        acc = f(acc, item)
    }

    return acc
}

fun <T, U> List<T>.customFoldRight(initial: U, f: (T, U) -> U): U {
    var acc = initial

    for (i in indices.reversed()) {
        acc = f(this[i], acc)
    }

    return acc
}

fun <T> List<T>.customReverse(): List<T> {
    val result = mutableListOf<T>()

    for (i in indices.reversed()) {
        result.add(this[i])
    }

    return result
}
