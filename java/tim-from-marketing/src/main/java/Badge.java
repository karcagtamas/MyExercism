import java.util.Locale;
import java.util.Objects;
import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.Stream;

class Badge {
    public String print(Integer id, String name, String department) {
       return Stream.of(Optional.ofNullable(id).map("[%s]"::formatted).orElse(null), name, Optional.ofNullable(department).orElse("owner").toUpperCase())
        .filter(Objects::nonNull)
        .collect(Collectors.joining(" - "));
    }
}
