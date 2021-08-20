export default class Raindrops {
  convert(x: number): string {
    var result: string = '';

    if (x % 3 === 0) {
      result += 'Pling';
    }

    if (x % 5 === 0) {
      result += 'Plang';
    }

    if (x % 7 === 0) {
      result += 'Plong';
    }

    return result ? result : x.toString();
  }
}
