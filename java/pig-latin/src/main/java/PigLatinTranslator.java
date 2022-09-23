import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class PigLatinTranslator {
	private static final List<String> vowels = List.of(
			"a",
			"e",
			"i",
			"o",
			"u",
			"xr",
			"yt"
	);

	private static final List<String> specialConsonantAfters = List.of(
			"qu"
	);

	private static final List<String> specialConsonant = List.of(
			"sch",
			"thr",
			"ch",
			"qu",
			"th",
			"rh"
	);

	String translate(String src) {
		return Arrays.stream(src.split(" ")).map(w -> {
					if (vowels.stream().anyMatch(w::startsWith)) {
						return String.format("%say", w);
					} else {
						var c = specialConsonantAfters.stream()
								.filter(x -> w.substring(1).startsWith(x))
								.findFirst();

						if (c.isPresent()) {
							return String.format("%s%say", w.substring(c.get().length() + 1), w.substring(0, c.get().length() + 1));
						}

						var c2 = specialConsonant.stream()
								.filter(w::startsWith)
								.findFirst();

						if (c2.isPresent()) {
							return String.format("%s%say", w.substring(c2.get().length()), w.substring(0, c2.get().length()));
						}

						return String.format("%s%say", w.substring(1), w.charAt(0));
					}
				}
		).collect(Collectors.joining(" "));
	}
}