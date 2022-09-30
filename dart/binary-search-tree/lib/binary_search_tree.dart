class BinarySearchTree {
  late final TreeNode root;

  List<String> get sortedData => _calcSortedData();

  BinarySearchTree(String rootValue) {
    root = TreeNode(rootValue);
  }

  void insert(String value) => root.append(value);

  List<String> _calcSortedData() => root.sort();
}

class TreeNode {
  final String data;

  TreeNode? left;
  TreeNode? right;

  TreeNode(this.data);

  void append(String value) {
    final v = int.parse(value);

    if (v <= int.parse(data)) {
      if (left == null) {
        left = TreeNode(value);
      } else {
        left?.append(value);
      }
    } else {
      if (right == null) {
        right = TreeNode(value);
      } else {
        right?.append(value);
      }
    }
  }

  List<String> sort() => [...left?.sort() ?? [], data, ...right?.sort() ?? []];
}
