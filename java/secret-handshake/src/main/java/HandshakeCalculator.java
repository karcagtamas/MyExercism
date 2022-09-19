import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Objects;

class HandshakeCalculator {

    List<Signal> calculateHandshake(int number) {
        final var binary = String.format("%5s", Integer.toBinaryString(number)).replace(' ', '0').split("");

        final var signals = List.of(Signal.WINK, Signal.DOUBLE_BLINK, Signal.CLOSE_YOUR_EYES, Signal.JUMP);
        final var result = new ArrayList<Signal>();

        for (int i = 0; i < signals.size(); i++) {
            if (binary[binary.length - 1 - i].equals("1")) {
                result.add(signals.get(i));
            }
        }

        if (Objects.equals(binary[binary.length - 5], "1")) {
            Collections.reverse(result);
        }

        return result;
    }

}
