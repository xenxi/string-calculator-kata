export function Add(input: string): number {
  if (isEmptyString(input)) {
    return 0;
  }

  const numbers = input.split(',').map(stringNumber => Number(stringNumber));

  return numbers.reduce((a: number,b: number)=> a + b);
}

function isEmptyString(input: string): boolean {
  return !input;
}

