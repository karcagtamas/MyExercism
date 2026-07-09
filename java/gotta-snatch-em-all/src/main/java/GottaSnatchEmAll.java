import java.util.Collections;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

class GottaSnatchEmAll {

    static Set<String> newCollection(List<String> cards) {
        return new HashSet<>(cards);
    }

    static boolean addCard(String card, Set<String> collection) {
        return collection.add(card);
    }

    static boolean canTrade(Set<String> myCollection, Set<String> theirCollection) {
        return !myCollection.containsAll(theirCollection) && !theirCollection.containsAll(myCollection);
    }

    static Set<String> commonCards(List<Set<String>> collections) {
        if (collections.isEmpty()) {
            return Collections.emptySet();
        }

        Set<String> result = new HashSet<>(collections.getFirst());

        for (int i = 1; i < collections.size(); i++) {
            result.retainAll(collections.get(i));
        }

        return result;
    }

    static Set<String> allCards(List<Set<String>> collections) {
        Set<String> result = new HashSet<>();

        for (Set<String> collection : collections) {
            result.addAll(collection);
        }

        return result;
    }
}
