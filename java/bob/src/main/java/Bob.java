class Bob {

    String hey(String input) {
        if (input.trim().isEmpty()) {
            return "Fine. Be that way!";
        }

        boolean isYelling = input.chars().allMatch(c -> !Character.isLetter(c) || Character.isUpperCase(c)) && input.chars().anyMatch(Character::isLetter);
        boolean isQuestion = input.trim().endsWith("?");

        if (isYelling && isQuestion) {
            return "Calm down, I know what I'm doing!";
        }

        if (isQuestion) {
            return "Sure.";
        }

        if (isYelling) {
            return "Whoa, chill out!";
        }

        return "Whatever.";
    }

}