import java.util.HashSet;
import java.util.Random;

class Robot {

    private static final String LETTERS = "QWERTZUIOPASDFGHJKLYXCVBNM";
    private static final HashSet<String> NAMES = new HashSet<>();
    private static final Random rnd = new Random();

    private String name;

    public Robot() {
        reset();
    }

    String getName() {
        return name;
    }

    void reset() {
        String newName;

        do {
            newName = "";
            newName += LETTERS.charAt(rnd.nextInt(0, LETTERS.length()));
            newName += LETTERS.charAt(rnd.nextInt(0, LETTERS.length()));
            newName += rnd.nextInt(0, 10);
            newName += rnd.nextInt(0, 10);
            newName += rnd.nextInt(0, 10);
        } while (NAMES.contains(newName));

        NAMES.add(newName);
        name = newName;
    }

}