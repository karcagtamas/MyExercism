class Gigasecond {
  constructor(private _date: Date) {}

  date(): Date {
    return new Date(this._date.getTime() + 10 ** 12);
  }
}

export default Gigasecond;
