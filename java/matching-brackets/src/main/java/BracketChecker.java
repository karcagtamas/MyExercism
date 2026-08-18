import java.util.Map;
import java.util.Stack;

class BracketChecker {

    private final String expression;

    private final Map<Character, Character> pairs = Map.of(
            ')', '(',
            '}', '{',
            ']', '['
    );

    BracketChecker(String expression) {
        this.expression = expression;
    }

    boolean areBracketsMatchedAndNestedCorrectly() {
        final var stack = new Stack<Character>();

        for (var ch : expression.chars().toArray()) {
            final Character c = (char) ch;
            if (pairs.containsValue(c)) {
                stack.push(c);
            } else if (pairs.containsKey(c)) {
                if (stack.isEmpty() || stack.pop() != pairs.get(c)) {
                    return false;
                }
            }
        }

        return stack.isEmpty();
    }

}