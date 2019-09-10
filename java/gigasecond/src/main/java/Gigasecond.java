import java.time.LocalDate;
import java.time.LocalDateTime;

class Gigasecond {

    private LocalDateTime moment;
    private static long GIGASECOND = 1_000_000_000;

    Gigasecond(LocalDate moment) {
        this.moment = moment.atStartOfDay();
    }

    Gigasecond(LocalDateTime moment) {
        this.moment = moment;
    }

    LocalDateTime getDateTime() {
        return moment.plusSeconds(GIGASECOND);
    }

}
