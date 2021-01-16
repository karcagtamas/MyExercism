//
// This is only a SKELETON file for the 'RNA Transcription' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

const TABLE = { DNA: "ACGT", RNA: "UGCA" };

export const toRna = (dna) => {
  return Array.from(dna)
    .map((x) => {
      return TABLE.RNA[TABLE.DNA.indexOf(x)];
    })
    .join("");
};
