export default class Hamming {
  compute(a: string, b: string): number {
    if (a.length != b.length) {
      throw 'DNA strands must be of equal length.';
    }

    let result = 0;

    for (let i = 0; i < a.length; i++) {
      if (a[i] != b[i]) {
        result++;
      }
    }

    return result;
  }
}
