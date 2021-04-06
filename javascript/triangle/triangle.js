//
// This is only a SKELETON file for the 'Triangle' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export class Triangle {
  constructor(...sides) {
    this.a = sides[0];
    this.b = sides[1];
    this.c = sides[2];
    this.inequal = this.isInequal();
  }

  get isEquilateral() {
    return this.a == this.b && this.a == this.c && this.a != 0;
  }

  get isIsosceles() {
    if (this.inequal) {
      return false;
    }
    return this.a == this.b || this.b == this.c || this.a == this.c;
  }

  get isScalene() {
    if (this.inequal) {
      return false;
    }
    return !this.isEquilateral && !this.isIsosceles;
  }

  isInequal() {
    return this.a + this.b < this.c || this.a + this.c < this.b || this.b + this.c < this.a;
  }
}
