class ChainNotFoundException(msg: String) : RuntimeException(msg)

data class Domino(val left: Int, val right: Int)

object Dominoes {

    fun formChain(vararg dominoes: Domino): List<Domino> {
        return formChain(dominoes.toList())
    }

    fun formChain(inputDominoes: List<Domino> = emptyList()): List<Domino> {
        if (inputDominoes.isEmpty()) return emptyList()

        return backtrack(
            chain = listOf(inputDominoes.first()),
            remaining = inputDominoes.drop(1),
        )?.takeIf {
            it.first().left == it.last().right
        } ?: throw ChainNotFoundException("Chain not found")
    }

    private fun backtrack(chain: List<Domino>, remaining: List<Domino>): List<Domino>? {
        if (remaining.isEmpty()) {
            return if (chain.first().left == chain.last().right) {
                chain
            } else {
                null
            }
        }

        val end = chain.last().right

        for (i in remaining.indices) {
            val d = remaining[i]

            val nextRemaining = remaining.take(i) + remaining.drop(i + 1)

            if (d.left == end) {
                val result = backtrack(chain + d, nextRemaining)

                if (result != null) return result
            }

            if (d.right == end) {
                val flipped = Domino(d.right, d.left)

                val result = backtrack(
                    chain + flipped,
                    nextRemaining,
                )

                if (result != null) return result
            }
        }

        return null
    }
}
