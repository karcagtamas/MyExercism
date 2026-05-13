public class RelativeDistance
{
    private readonly Dictionary<string, HashSet<string>> _graph = [];

    public RelativeDistance(Dictionary<string, string[]> familyTree)
    {
        foreach (var (parent, children) in familyTree)
        {
            foreach (var child in children)
            {
                AddConnection(parent, child);
                AddConnection(child, parent);
            }

            for (var i = 0; i < children.Length; i++)
            {
                for (var j = i + 1; j < children.Length; j++)
                {
                    AddConnection(children[i], children[j]);
                    AddConnection(children[j], children[i]);
                }
            }
        }
    }

    public int DegreeOfSeparation(string personA, string personB)
    {
        if (personA == personB)
        {
            return 0;
        }

        if (!_graph.ContainsKey(personA) || !_graph.ContainsKey(personB))
        {
            return -1;
        }

        var queue = new Queue<(string person, int distance)>();
        var visited = new HashSet<string>();

        queue.Enqueue((personA, 0));
        visited.Add(personA);

        while (queue.Count > 0)
        {
            var (current, distance) = queue.Dequeue();

            foreach (var neighbor in _graph[current])
            {
                if (visited.Contains(neighbor))
                {
                    continue;
                }

                if (neighbor == personB)
                {
                    return distance + 1;
                }

                visited.Add(neighbor);
                queue.Enqueue((neighbor, distance + 1));
            }
        }

        return -1;
    }

    private void AddConnection(string from, string to)
    {
        if (!_graph.ContainsKey(from))
        {
            _graph[from] = [];
        }

        _graph[from].Add(to);
    }
}
