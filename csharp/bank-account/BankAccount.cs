public class BankAccount
{
    private readonly Lock sync = new();
    private bool closed = true;
    private decimal balance = 0;

    public void Open()
    {
        lock (sync)
        {
            EnsureClosed();

            closed = false;
            balance = 0m;
        }
    }

    public void Close()
    {
        lock (sync)
        {
            EnsureOpen();
            closed = true;
        }
    }

    public decimal Balance
    {
        get
        {
            lock (sync)
            {
                EnsureOpen();
                return balance;
            }
        }
    }

    public void Deposit(decimal change)
    {
        if (change < 0) throw new InvalidOperationException();

        lock (sync)
        {
            EnsureOpen();
            balance += change;
        }
    }

    public void Withdraw(decimal change)
    {
        if (change < 0) throw new InvalidOperationException();

        lock (sync)
        {
            EnsureOpen();
            if (change > balance) throw new InvalidOperationException();

            balance -= change;
        }
    }

    private void EnsureOpen()
    {
        if (closed) throw new InvalidOperationException();
    }

    private void EnsureClosed()
    {
        if (!closed) throw new InvalidOperationException();
    }
}
