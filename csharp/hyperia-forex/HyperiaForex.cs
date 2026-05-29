public struct CurrencyAmount(decimal amount, string currency)
{
    private decimal amount = amount;
    private string currency = currency;

    public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency) throw new ArgumentException();

        return a.amount == b.amount;
    }

    public static bool operator !=(CurrencyAmount a, CurrencyAmount b) => !(a == b);

    // TODO: implement comparison operators
    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency) throw new ArgumentException();

        return a.amount < b.amount;
    }

    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency) throw new ArgumentException();

        return a.amount > b.amount;
    }

    public static bool operator <=(CurrencyAmount a, CurrencyAmount b) => !(a > b);

    public static bool operator >=(CurrencyAmount a, CurrencyAmount b) => !(a < b);


    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency) throw new ArgumentException();

        return new CurrencyAmount(a.amount + b.amount, a.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency) throw new ArgumentException();

        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount a, decimal operand) => new(a.amount * operand, a.currency);

    public static CurrencyAmount operator /(CurrencyAmount a, decimal operand) => new(a.amount / operand, a.currency);

    public static explicit operator double(CurrencyAmount a) => (double)a.amount;

    public static implicit operator decimal(CurrencyAmount a) => a.amount;
}
