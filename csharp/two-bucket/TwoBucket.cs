public enum Bucket
{
    One,
    Two
}

public class TwoBucketResult
{
    public int Moves { get; set; }
    public Bucket GoalBucket { get; set; }
    public int OtherBucket { get; set; }
}

public class TwoBucket(int bucketOne, int bucketTwo, Bucket startBucket)
{
    private readonly int bucketOne = bucketOne;
    private readonly int bucketTwo = bucketTwo;
    private readonly Bucket startBucket = startBucket;

    public TwoBucketResult Measure(int goal)
    {
        if (goal > Math.Max(bucketOne, bucketTwo) || goal % Gcd(bucketOne, bucketTwo) != 0) throw new ArgumentException();

        var start = startBucket == Bucket.One ? (bucketOne, 0) : (0, bucketTwo);
        var queue = new Queue<((int b1, int b2) state, int moves)>();
        var visited = new HashSet<(int, int)>();

        queue.Enqueue((start, 1));
        visited.Add(start);

        while (queue.Count > 0)
        {
            var ((b1, b2), moves) = queue.Dequeue();

            if (b1 == goal || b2 == goal)
            {
                return new TwoBucketResult
                {
                    Moves = moves,
                    GoalBucket = b1 == goal ? Bucket.One : Bucket.Two,
                    OtherBucket = b1 == goal ? b2 : b1,
                };
            }

            var nextStates = new List<(int, int)>
            {
                (bucketOne, b2),
                (b1, bucketTwo),
                (0, b2),
                (b1, 0),  
            };

            var amount = Math.Min(b1, bucketTwo - b2);
            nextStates.Add((b1 - amount, b2 + amount));

            amount = Math.Min(b2, bucketOne - b1);
            nextStates.Add((b1 + amount, b2 - amount));

            foreach(var state in nextStates)
            {
                if (startBucket == Bucket.One && state == (0, bucketTwo)) continue;

                if (startBucket == Bucket.Two && state == (bucketOne, 0)) continue;

                if (visited.Add(state))
                {
                    queue.Enqueue((state, moves + 1));
                }
            }
        }

        throw new ArgumentException();
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }
}
