import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

class VariableLengthQuantity {

    List<String> encode(List<Long> numbers) {
        final var result = new ArrayList<String>();

        for (var number : numbers) {
            var stack = new Stack<Long>();
            var n = number;

            stack.push(n & 0x7F);
            n >>= 7;

            while (n > 0) {
                stack.push((n & 0x7F) | 0x80);
                n >>= 7;
            }

            for (var b : stack.reversed()) {
                result.add("0x%s".formatted(Long.toHexString(b)));
            }
        }

        return result;
    }

    List<String> decode(List<Long> bytes) {
        final var result = new ArrayList<String>();
        long value = 0L;
        boolean hasPartial = false;

        for (var b : bytes) {
            hasPartial = true;
            value = (value << 7) | (b & 0x7F);

            if ((b & 0x80) == 0) {
                result.add("0x%s".formatted(Long.toHexString(value)));
                value = 0L;
                hasPartial = false;
            }
        }

        if (hasPartial) {
            throw new IllegalArgumentException("Invalid variable-length quantity encoding");
        }

        return result;
    }
}
