class BinarySearchTree<T : Comparable<T>> {

    data class Node<T>(val data: T, var left: Node<T>? = null, var right: Node<T>? = null)

    var root: Node<T>? = null

    fun insert(value: T) {
        if (root == null) {
            root = Node(value)
            return
        }

        var node = root

        while (true) {
            if (value <= node!!.data) {
                if (node.left == null) {
                    node.left = Node(value)
                    return
                }
                node = node.left
            } else {
                if (node.right == null) {
                    node.right = Node(value)
                    return
                }
                node = node.right
            }
        }

    }

    fun asSortedList(): List<T> {
        val result = mutableListOf<T>()

        fun inorder(node: Node<T>?) {
            if (node == null) return
            inorder(node.left)
            result.add(node.data)
            inorder(node.right)
        }

        inorder(root)
        return result
    }

    fun asLevelOrderList(): List<T> {
        val result = mutableListOf<T>()
        val queue = ArrayDeque<Node<T>>()

        root?.let { queue.add(it) }

        while (queue.isNotEmpty()) {
            val node = queue.removeFirst()
            result.add(node.data)

            node.left?.let { queue.add(it) }
            node.right?.let { queue.add(it) }
        }

        return result
    }

}
