class Reactor<T> {

    interface Subscription {
        fun cancel()
    }

    private val computeCells = mutableListOf<ComputeCell>()

    open inner class Cell(
        initialValue: T
    ) {
        open var value: T = initialValue
            protected set
    }

    inner class InputCell(
        initialValue: T,
    ) : Cell(initialValue) {

        public override var value: T = initialValue
            set(newValue) {
                if (field == newValue) return

                field = newValue
                propagate()
            }

        private fun propagate() {
            val changed = mutableListOf<ComputeCell>()

            for (cell in computeCells) {
                val old = cell.value
                cell.recompute()

                if (old != cell.value) {
                    changed += cell
                }
            }

            changed.forEach { it.fireCallbacks() }
        }
    }

    inner class ComputeCell(
        vararg dependencies: Cell,
        private val compute: (List<T>) -> T,
    ) : Cell(
        compute(dependencies.map { it.value })
    ) {

        private val dependencies = dependencies.toList()
        private val callbacks = mutableMapOf<Int, (T) -> Unit>()
        private var nextId = 0

        init {
            computeCells += this
        }

        internal fun recompute() {
            value = compute(
                dependencies.map { it.value }
            )
        }

        fun addCallback(
            callback: (T) -> Unit,
        ): Subscription {
            val id = nextId++
            callbacks[id] = callback

            return object : Subscription {
                override fun cancel() {
                    callbacks.remove(id)
                }
            }
        }

        internal fun fireCallbacks() {
            callbacks.values.forEach { it(value) }
        }
    }
}
