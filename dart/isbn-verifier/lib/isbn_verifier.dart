// Put your code here

bool isValid(String isbn) {
  final numberKeys = isbn.replaceAll('-', '').split('');

  if (numberKeys.length != 10) {
    return false;
  }

  final List<int> numbers = [];
  for (var i = 0; i < numberKeys.length; i++) {
    if (i == numberKeys.length - 1) {
      if (numberKeys[i] == 'X') {
        numbers.add(10);
        continue;
      }
    }

    var res = int.tryParse(numberKeys[i]);

    if (res == null) {
      return false;
    }

    numbers.add(res);
  }

  var sum = 0;
  for (var i = 0; i < numbers.length; i++) {
    sum += numbers[i] * (numbers.length - i);
  }

  return sum % 11 == 0;
}
