class RemoteControlCar
{
    private int travelledDistance;
    private int Percentage => 100 - travelledDistance / 20;
    private bool Empty => Percentage <= 0;

    public static RemoteControlCar Buy() => new();

    public string DistanceDisplay() => $"Driven {travelledDistance} meters";

    public string BatteryDisplay()
    {
        return Empty
            ? "Battery empty"
            : $"Battery at {Percentage}%";
    }

    public void Drive()
    {
        if (Empty)
        {
            return;
        }

        travelledDistance += 20;
    }
}
