class Words {
  public count(sentence: string): Map<string, number> {
    const map: Map<string, number> = new Map();
    for (const i of sentence
      .toLowerCase()
      .trimStart()
      .trimEnd()
      .split(/[ \n\t]+/g)) {
      let val: number = (map.get(i) ?? 0) + 1;
      map.set(i, val);
    }
    return map;
  }
}

export default Words;
