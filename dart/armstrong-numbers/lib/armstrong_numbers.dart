import 'dart:math';

class ArmstrongNumbers {
  bool isArmstrongNumber(num number) {
    final String chars = number.toString();

    final num sum =
        chars.split("").fold(0, (num previousValue, String element) {
      return previousValue + (pow(int.parse(element), chars.length));
    });

    return sum == number;
  }
}
