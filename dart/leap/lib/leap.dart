class Leap {
  // Put your code here
  bool leapYear(int year) => (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
}
