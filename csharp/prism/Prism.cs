public static class Prism
{
    public readonly record struct LaserInfo(double X, double Y, double Angle);
    public readonly record struct PrismInfo(int Id, double X, double Y, double Angle);

    public static int[] FindSequence(LaserInfo laser, PrismInfo[] prisms)
    {
        var sequence = new List<int>();
        var currentX = laser.X;
        var currentY = laser.Y;
        var currentAngle = laser.Angle;

        for (int i = 0; i < 500; i++)
        {
            PrismInfo? nearest = null;
            var minDistance = double.MaxValue;

            // Calculate current direction vector once per hit
            var rad = currentAngle * (Math.PI / 180.0);
            var dxDir = Math.Cos(rad);
            var dyDir = Math.Sin(rad);

            foreach (var prism in prisms)
            {
                var dx = prism.X - currentX;
                var dy = prism.Y - currentY;
                var dist = Math.Sqrt(dx * dx + dy * dy);

                if (dist < 1e-7) continue;

                var pDx = dx / dist;
                var pDy = dy / dist;

                var dot = (pDx * dxDir) + (pDy * dyDir);

                if (dot > 0.999999) 
                {
                    if (dist < minDistance)
                    {
                        minDistance = dist;
                        nearest = prism;
                    }
                }
            }

            if (!nearest.HasValue) break;

            sequence.Add(nearest.Value.Id);
            currentX = nearest.Value.X;
            currentY = nearest.Value.Y;
            currentAngle += nearest.Value.Angle;
        }

        return [.. sequence];
    }
}
