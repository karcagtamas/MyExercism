public class JedliksToyCar {

    private int travelledDistance;

    public static JedliksToyCar buy() {
        return new JedliksToyCar();
    }

    public String distanceDisplay() {
        return "Driven %d meters".formatted(travelledDistance);
    }

    public String batteryDisplay() {
        if (isEmpty()) {
            return "Battery empty";
        }

        return "Battery at %d".formatted(getPercentage()) + "%";
    }

    public void drive() {
        if (isEmpty()) {
            return;
        }

        travelledDistance += 20;
    }

    private int getPercentage() {
        return 100 - travelledDistance / 20;
    }

    private boolean isEmpty() {
        return getPercentage() <= 0;
    }
}
