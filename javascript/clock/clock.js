//
// This is only a SKELETON file for the 'Clock' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export class Clock {

  constructor(hour, min = 0) {
    this.hour = 0;
    this.addHours(hour);
    this.min = 0;
    this.addMins(min);
  }

  toString() {
    return `${this.hour.toString().padStart(2, "0")}:${this.min.toString().padStart(2, "0")}`;
  }

  plus(min) {
    this.addMins(min);
    return this;
  }

  minus(min) {
    this.addMins(-min);
    return this;
  }

  equals(clock) {
    return this.hour == clock.getHour() && this.min == clock.getMin();
  }

  addHours(hour) {
    this.hour = (this.hour + hour) % 24;
    if (this.hour < 0) {
      this.hour = 24 + this.hour;
    }
  }

  addMins(min) {
    let sum = this.min + min;

    this.min = sum % 60;

    let hour = (sum - this.min) / 60;

    this.addHours(hour);

    if (this.min < 0) {
      this.min += 60;
      this.addHours(-1);
    }
  }

  getMin() {
    return this.min;
  }

  getHour() {
    return this.hour;
  }
}
