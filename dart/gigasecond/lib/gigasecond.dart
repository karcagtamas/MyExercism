import 'dart:math';

DateTime add(final DateTime birthDate) =>
    birthDate.add(Duration(seconds: pow(10, 9).toInt()));
