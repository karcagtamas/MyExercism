const SCRABLE_SCORES = [
  {
    letters: 'AEIOULNRST',
    score: 1,
  },
  {
    letters: 'DG',
    score: 2,
  },
  {
    letters: 'BCMP',
    score: 3,
  },
  {
    letters: 'FHVWY',
    score: 4,
  },
  {
    letters: 'K',
    score: 5,
  },
  {
    letters: 'JX',
    score: 8,
  },
  {
    letters: 'QZ',
    score: 10,
  },
];

export default function score(text: string | undefined) {
  if (!text) {
    return 0;
  }

  return [...text.toUpperCase()].reduce(
    (total, el) => total + letterScore(el),
    0
  );
}

function letterScore(letter: string): number {
  return SCRABLE_SCORES.find((x) => x.letters.includes(letter))?.score ?? 0;
}
