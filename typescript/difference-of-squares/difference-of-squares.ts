class Squares {
  constructor(private _n: number) {}

  public get squareOfSum(): number {
    let sum: number = 0;

    for (let i = 1; i <= this._n; i++) {
      sum += i;
    }

    return sum ** 2;
  }

  public get sumOfSquares(): number {
    let sum: number = 0;

    for (let i = 1; i <= this._n; i++) {
      sum += i ** 2;
    }

    return sum;
  }

  public get difference(): number {
    return this.squareOfSum - this.sumOfSquares;
  }
}

export default Squares;
