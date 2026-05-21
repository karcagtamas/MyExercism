public class BankAccount
{
    private readonly object sync = new();
    private bool closed = true;
    private decimal balance = 0;

    public void Open()
    {
        lock (sync)
        {
            if (!closed) throw new InvalidOperationException();

            closed = false;
            balance = 0;
        }
    }

    public void Close()
    {
        lock (sync)
        {
            if (closed) throw new InvalidOperationException();

            closed = true;
        }
    }

    public decimal Balance
    {
        get
        {
            lock (sync)
            {
                return closed
                    ? throw new InvalidOperationException()
                    : balance;
            }
        }
    }

    public void Deposit(decimal change)
    {
        if (change < 0) throw new InvalidOperationException();
        
        lock (sync)
        {
            if (closed) throw new InvalidOperationException();

            balance += change;
        }
    }

    public void Withdraw(decimal change)
    {
        if (change < 0) throw new InvalidOperationException();

        lock (sync)
        {
            if (closed) throw new InvalidOperationException();
            if (change > balance) throw new InvalidOperationException();

            balance -= change;
        }
    }
}
