interface INucleotideCount {
  A: number;
  C: number;
  G: number;
  T: number;
}

class NucleotideCount {
  static nucleotideCounts(rna: string): INucleotideCount {
    let counts: INucleotideCount = { A: 0, C: 0, G: 0, T: 0 };

    for (const r of [...rna]) {
      switch (r) {
        case 'A':
          counts.A++;
          break;
        case 'C':
          counts.C++;
          break;
        case 'G':
          counts.G++;
          break;
        case 'T':
          counts.T++;
          break;
        default:
          throw 'Invalid nucleotide in strand';
      }
    }

    return counts;
  }
}

export default NucleotideCount;
