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
});
