export function Add(input: string): number {
  if (isEmptyString(input)) {
    return 0;
  }

  const numbers = input.split(',').map(stringNumber => Number(stringNumber));
  let total = 0;

  numbers.forEach(number => {
    total += number;
  });

  return total;
}

function isEmptyString(input: string): boolean {
  return !input;
}

