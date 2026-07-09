public class LogLine {

    private final String logLine;
    private final LogLevel level;

    public LogLine(String logLine) {
        this.logLine = logLine;
        this.level = parseLine(logLine);
    }

    public LogLevel getLogLevel() {
        return level;
    }

    public String getOutputForShortLog() {
        return "%d:%s".formatted(code(level), logLine.substring(logLine.indexOf(':') + 1).trim());
    }

    private static int code(LogLevel level) {
        return switch (level) {
            case TRACE -> 1;
            case DEBUG -> 2;
            case INFO -> 4;
            case WARNING -> 5;
            case ERROR -> 6;
            case FATAL -> 42;
            case UNKNOWN -> 0;
        };
    }

    private static LogLevel parseLine(String logLine) {
        int startIndex = logLine.indexOf('[');
        int endIndex = logLine.indexOf(']');
        return parse(logLine.substring(startIndex + 1, endIndex));
    }

    private static LogLevel parse(String key) {
        return switch (key) {
            case "TRC" -> LogLevel.TRACE;
            case "DBG" -> LogLevel.DEBUG;
            case "INF" -> LogLevel.INFO;
            case "WRN" -> LogLevel.WARNING;
            case "ERR" -> LogLevel.ERROR;
            case "FTL" -> LogLevel.FATAL;
            default -> LogLevel.UNKNOWN;
        };
    }
}
