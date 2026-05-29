public struct Coord(ushort x, ushort y)
{
    public ushort X { get; } = x;
    public ushort Y { get; } = y;
}

public struct Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
{
    public Coord Coord1 { get; } = coord1;
    public Coord Coord2 { get; } = coord2;
    public Coord Coord3 { get; } = coord3;
    public Coord Coord4 { get; } = coord4;
}


public class ClaimsHandler
{
    private List<Plot> claims = [];

    public void StakeClaim(Plot plot)
    {
        if (IsClaimStaked(plot)) return;
        claims.Add(plot);
    }

    public bool IsClaimStaked(Plot plot) => claims.Contains(plot);

    public bool IsLastClaim(Plot plot) => claims.Count > 0 && plot.Equals(claims[^1]);

    public Plot GetClaimWithLongestSide()
    {
        return claims.MaxBy(plot =>
        {
            static double Distance(Coord a, Coord b)
            {
                int dx = a.X - b.X;
                int dy = a.Y - b.Y;

                return Math.Sqrt(dx * dx + dy * dy);
            }

            return new[]
            {
                Distance(plot.Coord1, plot.Coord2),
                Distance(plot.Coord2, plot.Coord3),
                Distance(plot.Coord3, plot.Coord4),
                Distance(plot.Coord4, plot.Coord1)
            }.Max();
        });
    }
}
