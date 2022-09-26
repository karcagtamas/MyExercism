class PascalsTriangle {
  List<List<int>> rows(int row) {
    return List.generate(row, (index) => index).fold([],
        (List<List<int>> previousValue, int element) {
      return [...previousValue, _calcNextRow(previousValue, element)];
    });
  }

  List<int> _calcNextRow(List<List<int>> triangle, int row) {
    if (row == 0) {
      return [1];
    }

    return List.generate(row + 1, (index) {
      if (index == 0 || index == row) {
        return 1;
      }

      return triangle[row - 1][index - 1] + triangle[row - 1][index];
    });
  }
}
