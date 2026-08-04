class Proverb {

    private final String[] words;

    Proverb(String[] words) {
        this.words = words;
    }

    String recite() {
        if (words.length == 0) {
            return "";
        }

        final var result = new StringBuilder();

        for (int i = 0; i < words.length; i++) {
            if (i == words.length - 1) {
                result.append("And all for the want of a %s.".formatted(words[0]));
            } else {
                result.append("For want of a %s the %s was lost.\n".formatted(words[i], words[i + 1]));
            }
        }

        return result.toString();
    }

}
