//
// This is only a SKELETON file for the 'Leap' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const isLeap = (num) => {
  return (num % 4 == 0 && num % 100 != 0) || num % 400 == 0;
};
