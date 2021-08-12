const MAPPING: { [code: string]: string } = {
  G: 'C',
  C: 'G',
  T: 'A',
  A: 'U',
};

class Transcriptor {
  toRna(dna: string): string {
    return [...dna]
      .map((c) => {
        const trans = MAPPING[c];

        if (!trans) {
          throw 'Invalid input DNA.';
        }

        return trans;
      })
      .join('');
  }
}

export default Transcriptor;
