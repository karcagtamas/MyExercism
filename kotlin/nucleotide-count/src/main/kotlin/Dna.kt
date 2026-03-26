import kotlin.text.forEach

class Dna (dna: String){

    val elements = mutableMapOf('A' to 0, 'C' to 0, 'G' to 0, 'T' to 0)

    init {
        dna.forEach {
            require(elements.containsKey(it))
            elements[it] = elements[it]!!.inc()
        }
    }

    val nucleotideCounts: Map<Char, Int> = elements.toMap()
}
