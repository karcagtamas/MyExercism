import java.time.Duration;
import java.time.Instant;
import java.util.ArrayList;
import java.util.List;

public class SplitSecondStopwatch {

    private State state = State.READY;
    private Duration lapStart = Duration.ZERO;
    private Duration currentLap = Duration.ZERO;
    private final ArrayList<Duration> laps = new ArrayList<>();
    private Duration elapsed = Duration.ZERO;


    public void start() {
        if (state != State.READY && state != State.STOPPED) {
            throw new IllegalStateException("cannot start an already running stopwatch");
        }

        lapStart = elapsed;
        state = State.RUNNING;
    }

    public void stop() {
        if (state != State.RUNNING) {
            throw new IllegalStateException("cannot stop a stopwatch that is not running");
        }

        currentLap = currentLap.plus(elapsed.minus(lapStart));
        state = State.STOPPED;
    }

    public void reset() {
        if (state != State.STOPPED) {
            throw new IllegalStateException("cannot reset a stopwatch that is not stopped");
        }

        currentLap = Duration.ZERO;
        laps.clear();
        lapStart = null;
        state = State.READY;
    }

    public void lap() {
        if (state != State.RUNNING) {
            throw new IllegalStateException("cannot lap a stopwatch that is not running");
        }

        currentLap = currentLap.plus(elapsed.minus(lapStart));
        laps.add(currentLap);
        currentLap = Duration.ZERO;
        lapStart = elapsed;
    }

    public String state() {
        return state.getName();
    }

    public String currentLap() {
        if (state == State.RUNNING && lapStart != null) {
            return format(currentLap.plus(elapsed.minus(lapStart)));
        }

        return format(currentLap);
    }

    public String total() {
        var total = laps.stream()
                .reduce(Duration.ZERO, Duration::plus);

        if (state == State.RUNNING) {
            total = total.plus(currentLap).plus(elapsed.minus(lapStart));
        } else {
            total = total.plus(currentLap);
        }

        return format(total);
    }

    public java.util.List<String> previousLaps() {
        return laps.stream()
                .map(SplitSecondStopwatch::format)
                .toList();
    }

    public void advanceTime(String timeString) {
        elapsed = elapsed.plus(parse(timeString));
    }

    private static Duration parse(String s) {
        String[] parts = s.split(":");
        return Duration.ofHours(Long.parseLong(parts[0]))
                .plusMinutes(Long.parseLong(parts[1]))
                .plusSeconds(Long.parseLong(parts[2]));
    }

    private static String format(Duration d) {
        long seconds = d.getSeconds();

        long h = seconds / 3600;
        long m = (seconds % 3600) / 60;
        long s = seconds % 60;

        return String.format("%02d:%02d:%02d", h, m, s);
    }

    private enum State {
        READY,
        RUNNING,
        STOPPED;


        public String getName() {
            return this.name().toLowerCase();
        }
    }
}