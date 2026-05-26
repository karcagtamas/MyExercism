public static class Tournament
{
    private class TeamStats
    {
        public int MP { get; set; }
        public int W { get; set; }
        public int D { get; set; }
        public int L { get; set; }
        public int P => W * 3 + D;
    }

    public static void Tally(Stream inStream, Stream outStream)
    {
        var teams = new Dictionary<string, TeamStats>();

        using var reader = new StreamReader(inStream, leaveOpen: true);

        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(';');

            if (parts.Length != 3) continue;

            var team1 = parts[0];
            var team2 = parts[1];
            var result = parts[2];

            if (!teams.TryGetValue(team1, out var t1))
            {
                t1 = new TeamStats();
                teams[team1] = t1;
            }

            if (!teams.TryGetValue(team2, out var t2))
            {
                t2 = new TeamStats();
                teams[team2] = t2;
            }

            t1.MP++;
            t2.MP++;

            switch (result)
            {
                case "win":
                    t1.W++;
                    t2.L++;
                    break;
                case "loss":
                    t1.L++;
                    t2.W++;
                    break;
                case "draw":
                    t1.D++;
                    t2.D++;
                    break;
            }
        }

        using var writer = new StreamWriter(outStream, leaveOpen: true);

        var lines = new List<string>
        {
            "Team                           | MP |  W |  D |  L |  P"
        };

        lines.AddRange(
            teams
                .OrderByDescending(t => t.Value.P)
                .ThenBy(t => t.Key)
                .Select(t =>
                {
                    var s = t.Value;
                    return $"{t.Key,-30} | {s.MP,2} | {s.W,2} | {s.D,2} | {s.L,2} | {s.P,2}";
                }));

        for (int i = 0; i < lines.Count; i++)
        {
            if (i == lines.Count - 1)
                writer.Write(lines[i]);
            else
                writer.WriteLine(lines[i]);
        }

        writer.Flush();
    }
}
