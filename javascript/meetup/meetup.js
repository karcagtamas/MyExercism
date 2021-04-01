//
// This is only a SKELETON file for the 'Meetup' exercise. It's been provided as a
// convenience to get you started writing code faster.
//
const TEENTH_DAYS = [13, 14, 15, 16, 17, 18, 19];
const DAYS = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
const NUMBERS = ["first", "second", "third", "fourth", "fifth"];

export const meetup = (year, month, type, day) => {
  let dayIndex = DAYS.indexOf(day);
  if (type == "teenth") {
    let date = new Date(year, month - 1, TEENTH_DAYS[0]);
    while (dayIndex != date.getDay()) {
      date.setDate(date.getDate() + 1);
    }
    return date;
  } else if (NUMBERS.includes(type)) {
    let date = new Date(year, month - 1, 1);
    let c = 0;
    let number = NUMBERS.indexOf(type) + 1;
    do {
      if (dayIndex == date.getDay()) {
        c++;
        if (c != number) {
          date.setDate(date.getDate() + 7);
        }
      } else {
        date.setDate(date.getDate() + 1);
      }
    }while (c != number);
    return date;
  } else if (type == "last") {
    let date = new Date(year, month, 1);
    date.setDate(date.getDate() - 1);
    while (dayIndex != date.getDay()) {
      date.setDate(date.getDate() - 1);
    }
    return date;
  }
  return new Date();
};
