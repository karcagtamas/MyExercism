export default class Triangle {
  sides: number[];

  constructor(...sides: number[]) {
    this.sides = sides;
  }

  kind(): string {
    if (!this.isValid()) {
      throw "Invalid Triangle";
    }

    if (this.isEqualateral()) {
      return "equilateral";
    }

    if (this.isIsosceles()) {
      return "isosceles";
    }

    return "scalene";
  }

  private isEqualateral(): boolean {
    return this.sides[0] == this.sides[1] && this.sides[0] == this.sides[2];
  }

  private isIsosceles(): boolean {
    return (
      this.sides[0] == this.sides[1] ||
      this.sides[0] == this.sides[2] ||
      this.sides[1] == this.sides[2]
    );
  }

  private isValid(): boolean {
    if (this.sides.filter((x) => x <= 0).length != 0) {
      return false;
    }

    if (!this.check(0, 1, 2) || !this.check(0, 2, 1) || !this.check(1, 2, 0)) {
      return false;
    }

    return true;
  }

  private check(i1: number, i2: number, iexp: number): boolean {
    return this.sides[i1] + this.sides[i2] >= this.sides[iexp];
  }
}
