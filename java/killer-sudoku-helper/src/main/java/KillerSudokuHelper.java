import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.List;

public class KillerSudokuHelper {

    List<List<Integer>> combinationsInCage(Integer cageSum, Integer cageSize, List<Integer> exclude) {
        final var result = new ArrayList<ArrayList<Integer>>();

        generate(1, cageSum, cageSize, new ArrayList<>(), new HashSet<>(exclude), result);

        return List.copyOf(result);
    }

    List<List<Integer>> combinationsInCage(Integer cageSum, Integer cageSize) {
        return combinationsInCage(cageSum, cageSize, Collections.emptyList());
    }

    private static void generate(Integer start, Integer remainingSum, Integer remainingSize, ArrayList<Integer> current, HashSet<Integer> excluded, ArrayList<ArrayList<Integer>> result) {
        if (remainingSize == 0) {
            if (remainingSum == 0) {
                result.add(new ArrayList<>(current));
            }

            return;
        }

        for (var digit = start; digit <= 9; digit++) {
            if (excluded.contains(digit)) {
                continue;
            }

            if (digit > remainingSum) {
                break;
            }

            current.add(digit);

            generate(
                    digit + 1,
                    remainingSum - digit,
                    remainingSize - 1,
                    current,
                    excluded,
                    result
            );

            current.removeLast();
        }
    }

}
