//
// This is only a SKELETON file for the 'RNA Transcription' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

const TRANSCRIPTION = {
  C: "G",
  G: "C",
  A: "U",
  T: "A",
};

export const toRna = (dna) => {
  return Array.from(dna)
    .map((x) => TRANSCRIPTION[x.toUpperCase()])
    .join("");
};
