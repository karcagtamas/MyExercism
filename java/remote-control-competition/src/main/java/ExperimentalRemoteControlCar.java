public class ExperimentalRemoteControlCar implements RemoteControlCar {

    private int travelledDistance;

    public void drive() {
        travelledDistance += 20;
    }

    public int getDistanceTravelled() {
        return travelledDistance;
    }
}
