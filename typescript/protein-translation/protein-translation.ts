const PROTEIN_TRANSLATIONS: { protein: string; rna: string[] }[] = [
  { protein: 'Methionine', rna: ['AUG'] },
  { protein: 'Phenylalanine', rna: ['UUU', 'UUC'] },
  { protein: 'Leucine', rna: ['UUA', 'UUG'] },
  { protein: 'Serine', rna: ['UCU', 'UCC', 'UCA', 'UCG'] },
  { protein: 'Tyrosine', rna: ['UAU', 'UAC'] },
  { protein: 'Cysteine', rna: ['UGU', 'UGC'] },
  { protein: 'Tryptophan', rna: ['UGG'] },
  { protein: 'STOP', rna: ['UAA', 'UAG', 'UGA'] },
];

const IS_STOP = (protein: string) => protein === 'STOP';

class ProteinTranslation {
  static proteins(rna: string): string[] {
    let result: string[] = [];
    while (rna) {
      let seq: string = rna.substr(0, 3);
      rna = rna.substr(3);

      let translation = PROTEIN_TRANSLATIONS.find((trans) =>
        trans.rna.includes(seq)
      );
      if (translation) {
        if (IS_STOP(translation.protein)) {
          break;
        }
        result.push(translation.protein);
      }
    }

    return result;
  }
}

export default ProteinTranslation;
