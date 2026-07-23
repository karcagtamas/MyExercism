import java.util.Arrays;
import java.util.List;
import java.util.Objects;

class KindergartenGarden {

    private final List<String> rows;
    private final List<String> students = List.of(
            "Alice", "Bob", "Charlie", "David",
            "Eve", "Fred", "Ginny", "Harriet",
            "Ileana", "Joseph", "Kincaid", "Larry"
    );

    KindergartenGarden(String garden) {
        rows = Arrays.stream(garden.split("\n")).toList();
    }

    List<Plant> getPlantsOfStudent(String student) {
        final var i = students.indexOf(student);

        if (i == -1) {
            throw new IllegalArgumentException("Unknown student");
        }

        final var start = i * 2;

        return List.of(
                Objects.requireNonNull(Plant.getPlant(rows.get(0).charAt(start))),
                Objects.requireNonNull(Plant.getPlant(rows.get(0).charAt(start + 1))),
                Objects.requireNonNull(Plant.getPlant(rows.get(1).charAt(start))),
                Objects.requireNonNull(Plant.getPlant(rows.get(1).charAt(start + 1)))
        );
    }

}
