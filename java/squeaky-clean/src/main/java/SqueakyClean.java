class SqueakyClean {
    static String clean(String identifier) {
        final var result = new StringBuilder();

        var upperNext = false;

        for (var c : identifier.toCharArray()) {
            if (c == ' ') {
                result.append('_');
            } else if (Character.isISOControl(c)) {
                result.append("CTRL");
            } else if (c == '-') {
                upperNext = true;
            } else if (c >= 'α' && c <= 'ω') {
                continue;
            } else if (c >= '0' && c <= '9') {
                switch (c) {
                    case '0': c = 'o'; break;
                    case '1': c = 'l'; break;
                    case '3': c = 'e'; break;
                    case '4': c = 'a'; break;
                    case '7': c = 't'; break;
                }
            }

            if (Character.isLetter(c)) {
                result.append(upperNext ? Character.toUpperCase(c) : c);
                upperNext = false;
            }
        }

        return result.toString();
    }
}
