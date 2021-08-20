const ALLERGIES = [
  { name: 'eggs', value: 1 },
  { name: 'peanuts', value: 2 },
  { name: 'shellfish', value: 4 },
  { name: 'strawberries', value: 8 },
  { name: 'tomatoes', value: 16 },
  { name: 'chocolate', value: 32 },
  { name: 'pollen', value: 64 },
  { name: 'cats', value: 128 },
];

export default class Allergies {
  private allergyList: string[] = [];

  constructor(private allergies: number) {
    this.determineAllergies();
  }

  private determineAllergies(): void {
    let num: number = this.allergies;

    while (num != 0) {
      let number = this.findAllergyNumber(num);
      let allergy = ALLERGIES.find((x) => x.value === number);
      if (allergy) {
        this.allergyList.unshift(allergy.name);
        num -= allergy.value;
      } else {
        num -= number;
      }
    }
  }

  private getBiggestAllergy(num: number): { name: string; value: number } {
    return ALLERGIES.filter((x) => x.value <= num).sort((a, b) =>
      a.value > b.value ? -1 : a.value === b.value ? 0 : 1
    )[0];
  }

  private findAllergyNumber(num: number): number {
    let value = 1;
    while (num >= value * 2) {
      value = value * 2;
    }

    return value;
  }

  allergicTo(allergy: string): boolean {
    return this.allergyList.includes(allergy);
  }

  list(): string[] {
    return this.allergyList;
  }
}
