//
// This is only a SKELETON file for the 'RNA Transcription' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

const DNA = "ACGT";
const RNA = "UGCA";

export const toRna = dna => {
  let rna = "";
  for (const i of dna) {
    rna += RNA[DNA.indexOf(i)];
  }
  return rna;
};
