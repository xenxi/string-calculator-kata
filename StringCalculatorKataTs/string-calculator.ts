export function Add(input: string): number {
  if (isEmptyString(input)) {
    return 0;
  }

  const numbers = ReadNumbers(input);
  return Sum(numbers);
}

function Sum(numbers: number[]): number {
  return numbers.reduce((a: number, b: number) => a + b);
}

function ReadNumbers(input: string): number[] {
  return input.split(',').map(stringNumber => Number(stringNumber));
}

function isEmptyString(input: string): boolean {
  return !input;
}

