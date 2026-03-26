fun translate(rna: String?): List<String> {
    return rna?.let { rna ->
        rna
            .chunked(3)
            .map { translateSequence(it) }
            .takeWhile { it != "STOP" }
            .also {
                it.forEach {
                    require(it != "")
                }
            }
    } ?: emptyList()
}

fun translateSequence(rna: String): String = when (rna) {
    "AUG" -> "Methionine"
    "UUU", "UUC" -> "Phenylalanine"
    "UUA", "UUG" -> "Leucine"
    "UCU", "UCC", "UCA", "UCG" -> "Serine"
    "UAU", "UAC" -> "Tyrosine"
    "UGU", "UGC" -> "Cysteine"
    "UGG" -> "Tryptophan"
    "UAA", "UAG", "UGA" -> "STOP"
    else -> ""
}