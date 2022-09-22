import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

public class Anagram {
	private final String text;

	public Anagram(String text) {
		this.text = text;
	}

	public List<String> match(List<String> texts) {
		final Map<String, Integer> textMap = GetTextMap(text);

		return texts.stream()
				.filter(x -> !text.equalsIgnoreCase(x))
				.filter(x -> {
					final var mapping = GetTextMap(x);

					return textMap.equals(mapping);
				})
				.collect(Collectors.toList());
	}

	private Map<String, Integer> GetTextMap(String text) {
		final Map<String, Integer> textMap = new HashMap<>();

		Arrays.stream(text.toLowerCase().split(""))
				.forEach(c -> {
					if (textMap.containsKey(c)) {
						textMap.put(c, textMap.get(c) + 1);
					} else {
						textMap.put(c, 1);
					}
				});

		return textMap;
	}
}
