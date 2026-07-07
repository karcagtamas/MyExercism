import java.util.*;

class RelativeDistance {

    private final Map<String, Set<String>> _graph = new HashMap<>();

    RelativeDistance(Map<String, List<String>> familyTree) {

        for (var entry : familyTree.entrySet()) {
            final var parent = entry.getKey();
            for (var child : entry.getValue()) {
                addConnection(parent, child);
                addConnection(child, parent);
            }

            for (var i = 0; i < entry.getValue().size(); i++) {
                for (var j = i + 1; j < entry.getValue().size(); j++) {
                    addConnection(entry.getValue().get(i), entry.getValue().get(j));
                    addConnection(entry.getValue().get(j), entry.getValue().get(i));
                }
            }
        }
    }

    int degreeOfSeparation(String personA, String personB) {
        if (Objects.equals(personA, personB)) {
            return 0;
        }

        if (!_graph.containsKey(personA) || !_graph.containsKey(personB)) {
            return -1;
        }

        final var queue = new LinkedList<Map.Entry<String, Integer>>();
        final var visited = new HashSet<String>();

        queue.push(Map.entry(personA, 0));
        visited.add(personA);

        while (!queue.isEmpty()) {
            final var entry = queue.pop();

            for (var neighbor : _graph.get(entry.getKey())) {
                if (visited.contains(neighbor)) {
                    continue;
                }

                if (Objects.equals(neighbor, personB)) {
                    return entry.getValue() + 1;
                }

                visited.add(neighbor);
                queue.push(Map.entry(neighbor, entry.getValue() + 1));
            }
        }

        return -1;
    }

    private void addConnection(String from, String to) {
        _graph.computeIfAbsent(from, key -> new HashSet<>()).add(to);
    }
}
