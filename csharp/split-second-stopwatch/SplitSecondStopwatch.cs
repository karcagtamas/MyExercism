public enum StopwatchState
{
    Ready,
    Running,
    Stopped
}

public class SplitSecondStopwatch(TimeProvider time)
{
    private long? startedAt;
    private TimeSpan currentLap = TimeSpan.Zero;
    private readonly List<TimeSpan> previousLaps = [];

    public StopwatchState State { get; private set; } = StopwatchState.Ready;
    public TimeSpan CurrentLap
    {
        get
        {
            if (State == StopwatchState.Running && startedAt.HasValue)
            {
                return currentLap + time.GetElapsedTime(startedAt.Value);
            }

            return currentLap;
        }
    }
    public TimeSpan Total => previousLaps.Aggregate(TimeSpan.Zero, (acc, lap) => acc + lap) + CurrentLap;
    public IReadOnlyCollection<TimeSpan> PreviousLaps => previousLaps.AsReadOnly();

    public void Start()
    {
        if (State != StopwatchState.Ready && State != StopwatchState.Stopped)
        {
            throw new InvalidOperationException("Invalid operation");
        }

        startedAt = time.GetTimestamp();
        State = StopwatchState.Running;
    }

    public void Stop()
    {
        if (State != StopwatchState.Running)
        {
            throw new InvalidOperationException("Invalid operation");
        }

        currentLap = CurrentLap;
        startedAt = null;

        State = StopwatchState.Stopped;
    }

    public void Reset()
    {
        if (State != StopwatchState.Stopped)
        {
            throw new InvalidOperationException("Invalid operation");
        }

        currentLap = TimeSpan.Zero;
        previousLaps.Clear();
        startedAt = null;
        State = StopwatchState.Ready;
    }

    public void Lap()
    {
        if (State != StopwatchState.Running)
        {
            throw new InvalidOperationException("Invalid operation");
        }

        previousLaps.Add(CurrentLap);

        currentLap = TimeSpan.Zero;
        startedAt = time.GetTimestamp();
    }
}
