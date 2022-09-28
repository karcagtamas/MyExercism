import java.util.HashMap;
import java.util.Map;

public class Blackjack {

    private static final Map<String, Integer> mappings;

    static {
        mappings = new HashMap<>();
        mappings.put("ace", 11);
        mappings.put("two", 2);
        mappings.put("three", 3);
        mappings.put("four", 4);
        mappings.put("five", 5);
        mappings.put("six", 6);
        mappings.put("seven", 7);
        mappings.put("eight", 8);
        mappings.put("nine", 9);
        mappings.put("ten", 10);
        mappings.put("jack", 10);
        mappings.put("queen", 10);
        mappings.put("king", 10);
    }

    public int parseCard(String card) {
        return mappings.getOrDefault(card, 0);
    }

    public boolean isBlackjack(String card1, String card2) {
        return parseCard(card1) + parseCard(card2) == 21;
    }

    public String largeHand(boolean isBlackjack, int dealerScore) {
        if (isBlackjack) {
            return dealerScore < 10 ? "W" : "S";
        }

        return "P";
    }

    public String smallHand(int handScore, int dealerScore) {
        if (handScore >= 17) {
            return "S";
        }

        if (handScore <= 11 || dealerScore >= 7) {
            return "H";
        }

        return "S";
    }

    // FirstTurn returns the semi-optimal decision for the first turn, given the cards of the player and the dealer.
    // This function is already implemented and does not need to be edited. It pulls the other functions together in a
    // complete decision tree for the first turn.
    public String firstTurn(String card1, String card2, String dealerCard) {
        int handScore = parseCard(card1) + parseCard(card2);
        int dealerScore = parseCard(dealerCard);

        if (20 < handScore) {
            return largeHand(isBlackjack(card1, card2), dealerScore);
        } else {
            return smallHand(handScore, dealerScore);
        }
    }
}
