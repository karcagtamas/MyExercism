import java.util.ArrayList;
import java.util.List;

class Allergies {

    private final List<Allergen> allergies = new ArrayList<>();

    Allergies(int score) {
        for (var allergen : Allergen.values()) {
            if ((score & allergen.getScore()) != 0) {
                allergies.add(allergen);
            }
        }
    }

    boolean isAllergicTo(Allergen allergen) {
        return allergies.contains(allergen);
    }

    List<Allergen> getList() {
        return allergies;
    }
}
