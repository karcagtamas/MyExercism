public class RemoteControlCar
{
    public TelemetrySystem Telemetry {get;}
    public string CurrentSponsor { get; private set; }

    private Speed currentSpeed;

    public RemoteControlCar()
    {
        Telemetry = new TelemetrySystem(this);
    }

    public void ShowSponsor_Telemetry(string sponsorName)
    {
        SetSponsor(sponsorName);
    }

    public void SetSpeed_Telemetry(decimal amount, string unitsString)
    {
        SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
        if (unitsString == "cps")
        {
            speedUnits = SpeedUnits.CentimetersPerSecond;
        }

        SetSpeed(new Speed(amount, speedUnits));
    }

    public string GetSpeed() => currentSpeed.ToString();

    private void SetSponsor(string sponsorName) => CurrentSponsor = sponsorName;

    private void SetSpeed(Speed speed) => currentSpeed = speed;

    public class TelemetrySystem
    {
        private readonly RemoteControlCar car;

        internal TelemetrySystem(RemoteControlCar car)
        {
            this.car = car;
        }

        public void Calibrate() {}

        public bool SelfText() => true;

        public void ShowSponsor(string sponsorName)
        {
            car.SetSponsor(sponsorName);
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            var speedUnits = SpeedUnits.MetersPerSecond;

            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            car.SetSpeed(new Speed(amount, speedUnits));
        }
    }
}

public enum SpeedUnits
{
    MetersPerSecond,
    CentimetersPerSecond
}

public struct Speed
{
    public decimal Amount { get; }
    public SpeedUnits SpeedUnits { get; }

    public Speed(decimal amount, SpeedUnits speedUnits)
    {
        Amount = amount;
        SpeedUnits = speedUnits;
    }

    public override string ToString()
    {
        string unitsString = "meters per second";
        if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
        {
            unitsString = "centimeters per second";
        }

        return Amount + " " + unitsString;
    }
}
