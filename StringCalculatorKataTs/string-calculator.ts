export function Add(input: string): number {
  if (input) {
    const numbers = input.split(',').map(stringNumber => Number(stringNumber));
    let total = 0;

    numbers.forEach(number => {
      total += number;
    });

    return total;
  }
  return 0;
}
