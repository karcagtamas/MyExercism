function transform(value: { [key: string]: string[] }): {
  [key: string]: number;
} {
  let result: {
    [key: string]: number;
  } = {};
  Object.keys(value).forEach((key) => {
    value[key].forEach((letter) => {
      result[letter.toLowerCase()] = Number(key);
    });
  });
  return result;
}

export default transform;
