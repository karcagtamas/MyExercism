import 'dart:math';

class DifferenceOfSquares {
  // Put your code here

  int squareOfSum(int num) => pow(
        List.generate(num, (int index) => index + 1)
            .fold(
              0,
              (int previousValue, int element) => previousValue + element,
            )
            .toDouble(),
        2,
      ).toInt();

  int sumOfSquares(int num) =>
      List.generate(num, (index) => pow(index + 1, 2).toInt())
          .fold(0, (previousValue, element) => previousValue + element);

  int differenceOfSquares(int num) => squareOfSum(num) - sumOfSquares(num);
}
