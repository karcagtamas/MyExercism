import java.util.*;

class Flattener {

    List<Object> flatten(List<?> list) {
        List<Object> result = new ArrayList<>();

        for (Object item : list) {
            if (item instanceof List<?> collection) {
                result.addAll(flatten(collection));
            } else if (item != null) {
                result.add(item);
            }
        }

        return result;
    }

}