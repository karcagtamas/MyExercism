export default class Pangram {
  constructor(private text: string) {}

  isPangram(): boolean {
    const testedText: string = this.text.toLowerCase();
    let isPangram = true;

    for (
      let charCode = 'a'.charCodeAt(0);
      charCode <= 'z'.charCodeAt(0);
      charCode++
    ) {
      let char: string = String.fromCharCode(charCode);

      if (!testedText.includes(char)) {
        isPangram = false;
        break;
      }
    }

    return isPangram;
  }
}
