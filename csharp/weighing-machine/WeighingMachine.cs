class WeighingMachine(int precision)
{
    public int Precision => precision;

    public double Weight
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            field = value;
        }
    }

    public double TareAdjustment { get; set; } = 5;

    public string DisplayWeight => $"{(Weight - TareAdjustment).ToString("F" + Precision)} kg";
}
