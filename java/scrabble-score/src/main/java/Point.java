public class Point {
    private final int point;
    private final String chars;

    public Point(int point, String chars) {
        this.point = point;
        this.chars = chars;
    }

    public int getPoint() {
        return this.point;
    }

    public String getChars() {
        return this.chars;
    }

    public boolean isContains(Character character) {
        return chars.contains(character.toString());
    }
}
