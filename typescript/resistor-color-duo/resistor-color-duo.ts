const COLORS = [
  "black",
  "brown",
  "red",
  "orange",
  "yellow",
  "green",
  "blue",
  "violet",
  "grey",
  "white",
];

export class ResistorColor {
  private colors: string[];

  constructor(colors: string[]) {
    if (!colors || colors.length < 2) {
      throw "At least two colors need to be present";
    }
    this.colors = colors;
  }
  value = (): number => {
    return parseInt(
      (COLORS.findIndex((x) => x === this.colors[0])?.toString() ?? "0") +
        (COLORS.findIndex((x) => x === this.colors[1])?.toString() ?? "0")
    );
  };
}
