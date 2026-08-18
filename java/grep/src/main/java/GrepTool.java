import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;

class GrepTool {

    String grep(String pattern, List<String> flags, List<String> files) {
        boolean lineNumbers = flags.contains("-n");
        boolean fileNamesOnly = flags.contains("-l");
        boolean ignoreCase = flags.contains("-i");
        boolean invert = flags.contains("-v");
        boolean exact = flags.contains("-x");

        boolean multipleFiles = files.size() > 1;

        final var results = new ArrayList<String>();

        for (var file : files) {
            try {
                var lines = Files.readAllLines(Path.of(file));

                for (int i = 0; i < lines.size(); i++) {
                    var line = lines.get(i);
                    boolean match = exact
                            ? (ignoreCase ? pattern.equalsIgnoreCase(line) : pattern.equals(line))
                            : (ignoreCase ? line.toLowerCase().contains(pattern.toLowerCase()) : line.contains(pattern));

                    if (invert) match = !match;

                    if (!match) continue;

                    if (fileNamesOnly) {
                        results.add(file);
                        break;
                    }

                    var output = new StringBuilder();

                    if (multipleFiles) {
                        output.append(file).append(":");
                    }

                    if (lineNumbers) {
                        output.append(i + 1).append(":");
                    }

                    output.append(line);
                    results.add(output.toString());
                }
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }

        return String.join("\n", results);
    }

}