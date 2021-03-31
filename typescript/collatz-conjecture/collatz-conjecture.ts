class CollatzConjecture {
  static steps(num: number): number {
    if (num <= 0) {
      throw "Only positive numbers are allowed";
    }

    let step = 0;
    while (num != 1) {
      num = num % 2 == 0 ? num / 2 : num * 3 + 1;
      step++;
    }

    return step;
  }
}

export default CollatzConjecture;
