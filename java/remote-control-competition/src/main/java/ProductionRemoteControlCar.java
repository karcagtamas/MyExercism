class ProductionRemoteControlCar implements RemoteControlCar, Comparable<ProductionRemoteControlCar> {

    private int travelledDistance;
    private int numberOfVictories;

    public void drive() {
        travelledDistance += 10;
    }

    public int getDistanceTravelled() {
        return travelledDistance;
    }

    public int getNumberOfVictories() {
        return numberOfVictories;
    }

    public void setNumberOfVictories(int numberOfVictories) {
        this.numberOfVictories = numberOfVictories;
    }

    @Override
    public int compareTo(ProductionRemoteControlCar o) {
        return o.numberOfVictories - numberOfVictories;
    }
}
