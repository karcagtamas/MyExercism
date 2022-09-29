import java.util.regex.Pattern;

public class LogLevels {

	public static String message(String logLine) {
		return logLine.replaceAll("\\[[A-Z]*]:", "").trim();
	}

	public static String logLevel(String logLine) {
		final var pattern = Pattern.compile("\\[([A-Z]*)]:");

		final var matcher = pattern.matcher(logLine);

		if (matcher.find()) {
			return matcher.group(1).toLowerCase();
		}

		return "";
	}

	public static String reformat(String logLine) {
		return "%s (%s)".formatted(message(logLine), logLevel(logLine));
	}
}
