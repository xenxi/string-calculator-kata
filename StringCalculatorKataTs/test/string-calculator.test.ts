import { Add } from '../string-calculator';
describe('StringCalculator should', () => {
    it('return 0 when string is empty', () => {
        const result = Add('');

        expect(result).toBe(0);
    });
    it('return 0 when string is 0', () => {
        const result = Add('0');

        expect(result).toBe(0);
    });
    it('return 1 when string is 1', () => {
        const result = Add('1');

        expect(result).toBe(1);
    });
    it('return 2 when string is 2', () => {
        const result = Add('2');

        expect(result).toBe(2);
    });
});
