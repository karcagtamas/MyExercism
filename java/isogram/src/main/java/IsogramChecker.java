import java.util.Arrays;

import static java.util.function.Predicate.not;
import static java.util.stream.Collectors.toSet;

class IsogramChecker {

    boolean isIsogram(String phrase) {
        var modified = phrase.replaceAll("[- ]", "").toLowerCase();
        return Arrays.stream(modified.split("")).filter(not(String::isEmpty)).collect(toSet()).size() == modified.length();
    }

}
