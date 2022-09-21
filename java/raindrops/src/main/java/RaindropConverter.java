import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Map;

class RaindropConverter {

	private static final Map<Integer, String> drops = Map.of(3, "Pling", 5, "Plang", 7, "Plong");

	String convert(int number) {
		final var factors = getFactors(number);

		StringBuilder resultBuilder = new StringBuilder();

		drops.entrySet().stream()
				.sorted(Map.Entry.comparingByKey())
				.forEach(entry -> {
					if (factors.contains(entry.getKey())) {
						resultBuilder.append(entry.getValue());
					}
				});

		var result = resultBuilder.toString();

		return result.isEmpty() ? String.valueOf(number) : result;
	}

	List<Integer> getFactors(int number) {
		final var factors = new ArrayList<Integer>();
		factors.add(1);

		for (int i = 2; i <= number / 2; i++) {
			if (number % i == 0) {
				factors.add(i);
			}
		}

		factors.add(number);
		return factors;
	}

}
