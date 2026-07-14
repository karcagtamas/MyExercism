public class PangramChecker {

    public boolean isPangram(String input) {
        final int[] arr = new int['z' - 'a' + 1];

        for (var ch : input.toLowerCase().toCharArray()) {
            if (ch >= 'a' && ch <= 'z') {
                arr[ch - 'a']++;
            }
        }

        for (var i : arr) {
            if (i <= 0) {
                return false;
            }
        }

        return true;
    }

}
