import java.util.Arrays;
import java.util.stream.Collectors;

class SqueakyClean {
	static String clean(String identifier) {
		var stringBuilder = new StringBuilder();
		var array = identifier.split("");


		for (int i = 0; i < array.length; i++) {
			var c = array[i];

			if (c.isEmpty()) {
				continue;
			}

			var character = c.charAt(0);
			if (c.equals(" ")) {
				stringBuilder.append("_");
			} else if (Character.isISOControl(character)) {
				stringBuilder.append("CTRL");
			} else if (character == '-') {
				if (i < array.length - 1) {
					var nextI = i + 1;

					while (nextI < array.length - 1 && !Character.isLetter(array[nextI].charAt(0))) {
						nextI++;
					}

					stringBuilder.append(array[nextI].toUpperCase());
					i = nextI;
				}
			} else if (Character.isAlphabetic(character)) {
				stringBuilder.append(c.replaceAll("[α-ω]", ""));
			}
		}

		return stringBuilder.toString();
	}
}
