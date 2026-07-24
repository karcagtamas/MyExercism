import java.util.*;

public class Prism {

    public record LaserInfo(double x, double y, double angle) {
    }

    public record PrismInfo(int id, double x, double y, double angle) {
    }

    public static List<Integer> findSequence(LaserInfo laser, List<PrismInfo> prisms) {
        var sequence = new ArrayList<Integer>();
        var currentX = laser.x();
        var currentY = laser.y();
        var currentAngle = laser.angle();

        for (int i = 0; i < 500; i++) {
            PrismInfo nearest = null;
            var minDistance = Double.MAX_VALUE;

            var rad = currentAngle * (Math.PI / 180.0);
            var dxDir = Math.cos(rad);
            var dyDir = Math.sin(rad);

            for (var prism : prisms) {
                var dx = prism.x() - currentX;
                var dy = prism.y() - currentY;
                var dist = Math.sqrt(dx * dx + dy * dy);

                if (dist < 1e-7) continue;

                var pDx = dx / dist;
                var pDy = dy / dist;

                var dot = (pDx * dxDir) + (pDy * dyDir);

                if (dot > 0.999999 && dist < minDistance) {
                    minDistance = dist;
                    nearest = prism;
                }
            }

            if (nearest == null) break;

            sequence.add(nearest.id());
            currentX = nearest.x();
            currentY = nearest.y();
            currentAngle += nearest.angle();
        }

        return List.copyOf(sequence);
    }
}