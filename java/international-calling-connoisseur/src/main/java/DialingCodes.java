import java.util.HashMap;
import java.util.Map;
import java.util.Objects;
import java.util.Optional;

public class DialingCodes {

    final Map<Integer, String> codes = new HashMap<>();

    public Map<Integer, String> getCodes() {
        return codes;
    }

    public void setDialingCode(Integer code, String country) {
        codes.put(code, country);
    }

    public String getCountry(Integer code) {
        return codes.get(code);
    }

    public void addNewDialingCode(Integer code, String country) {
        if (codes.containsKey(code) || codes.containsValue(country)) {
            return;
        }

        codes.put(code, country);
    }

    public Integer findDialingCode(String country) {
        return codes.entrySet().stream()
            .filter(entry -> Objects.equals(entry.getValue(), country))
            .findFirst()
            .map(Map.Entry::getKey)
            .orElse(null);
    }

    public void updateCountryDialingCode(Integer code, String country) {
        Optional.ofNullable(findDialingCode(country)).ifPresent(oldCode -> {
            codes.remove(oldCode);
            codes.put(code, country);
        });
    }
}
