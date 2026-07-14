class Acronym {

    private final String abbreviate;

    Acronym(String phrase) {
        StringBuilder abbr = new StringBuilder();

        final var words = phrase.replace("_", "").replace('-', ' ').split(" ");

        for (var word : words) {
            if (!word.isEmpty()) {
                abbr.append(word.substring(0, 1).toUpperCase());
            }
        }

        abbreviate = abbr.toString();
    }

    String get() {
        return abbreviate;
    }

}
