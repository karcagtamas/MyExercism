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

            if (field != value)
            {
                cachedDisplay = null;
            }

            field = value;
        }
    }

    public double TareAdjustment { get; set; } = 5;

    private string? cachedDisplay;

    public string DisplayWeight
    {
        get
        {
            if (cachedDisplay is not null)
                return cachedDisplay;

            var format = "F" + Precision;
            var adjusted = Weight - TareAdjustment;

            cachedDisplay = $"{adjusted.ToString(format)} kg";
            return cachedDisplay;
        }
    }
}
