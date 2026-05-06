class RemoteControlCar(int speed, int batteryDrain)
{
    private int battery = 100;
    private int distanceDriven;

    public int Speed { get; init; } = speed;
    public int BatteryDrain { get; init; } = batteryDrain;

    public bool BatteryDrained() => battery < BatteryDrain;

    public int DistanceDriven() => distanceDriven;

    public void Drive()
    {
        if (BatteryDrained()) return;

        distanceDriven += Speed;
        battery -= BatteryDrain;
    }

    public static RemoteControlCar Nitro() => new(50, 4);
}

class RaceTrack(int distance)
{
    private readonly int distance = distance;

    public bool TryFinishTrack(RemoteControlCar car) => 100 / car.BatteryDrain * car.Speed >= distance;
}
