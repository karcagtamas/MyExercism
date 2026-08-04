import java.time.Duration;
import java.time.Instant;
import java.util.HashMap;
import java.util.Map;

public class RateLimiter<K> {

    private final int limit;
    private final Duration windowSize;
    private final TimeSource timeSource;

    private final Map<K, ClientWindow> clients = new HashMap<>();

    public RateLimiter(int limit, Duration windowSize, TimeSource timeSource) {
        this.limit = limit;
        this.windowSize = windowSize;
        this.timeSource = timeSource;
    }

    public boolean allow(K clientId) {
        final var now = timeSource.now();

        final var window = clients.get(clientId);

        if (window == null) {
            clients.put(clientId, new ClientWindow(now, 1));
            return true;
        }

        if (!now.isBefore(window.start.plus(windowSize))) {
            clients.put(clientId, new ClientWindow(now, 1));
            return true;
        }

        if (window.count >= limit) {
            return false;
        }

        window.count++;
        return true;
    }

    private static class ClientWindow {
        private final Instant start;
        private int count;

        private ClientWindow(Instant start, int count) {
            this.start = start;
            this.count = count;
        }
    }
}
