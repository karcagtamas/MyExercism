public class Reactor
{
    private readonly List<ComputeCell> computeCells = [];

    public InputCell CreateInputCell(int value) => new(value, this);

    public ComputeCell CreateComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute) => new(producers, compute, this);

    internal void Propogate()
    {
        var changed = new List<ComputeCell>();

        foreach (var cell in computeCells)
        {
            int old = cell.Value;

            cell.Recompute();

            if (old != cell.Value)
            {
                changed.Add(cell);
            }
        }

        foreach (var cell in changed)
        {
            cell.FireCallbacks();
        }
    }

    internal void Register(ComputeCell cell) => computeCells.Add(cell);
}

public abstract class Cell(int initialValue)
{
    public int Value { get; protected set; } = initialValue;
}

public class InputCell(int initialValue, Reactor reactor) : Cell(initialValue)
{
    private readonly Reactor reactor = reactor;

    public new int Value
    {
        get => base.Value;
        set
        {
            if (base.Value == value) return;

            base.Value = value;
            reactor.Propogate();
        }
    }
}

public class ComputeCell : Cell
{
    private readonly List<Cell> dependencies;
    private readonly Func<int[], int> compute;
    private readonly Dictionary<int, Action<int>> callbacks = [];
    private int nextId;

    public ComputeCell(IEnumerable<Cell> dependencies, Func<int[], int> compute, Reactor reactor) : base(compute([.. dependencies.Select(d => d.Value)]))
    {
        this.dependencies = [.. dependencies];
        this.compute = compute;

        reactor.Register(this);
    }

    internal void Recompute() => Value = compute([.. dependencies.Select(d => d.Value)]);

    public IDisposable AddCallback(Action<int> callback)
    {
        int id = nextId++;
        callbacks[id] = callback;
        return new Subscription(() => callbacks.Remove(id));
    }

    internal void FireCallbacks()
    {
        foreach (var callback in callbacks.Values)
        {
            callback(Value);
        }
    }

    private sealed class Subscription(Action cancel) : IDisposable
    {
        public void Dispose() => cancel();
    }
}