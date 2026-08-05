import java.time.DayOfWeek;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.time.YearMonth;

public class SwiftScheduling {
    public static LocalDateTime convertToDeliveryDate(LocalDateTime meetingStart, String description) {
        return switch (description) {
            case "NOW" -> meetingStart.plusHours(2);
            case "ASAP" -> getAsap(meetingStart);
            case "EOW" -> getEndOfWeek(meetingStart);
            default -> {
                if (description.endsWith("M")) {
                    yield getMonth(meetingStart, description);
                }

                if (description.startsWith("Q")) {
                    yield getQuarter(meetingStart, description);
                }

                throw new IllegalArgumentException();
            }
        };
    }

    private static LocalDateTime getAsap(LocalDateTime meeting) {
        return meeting.getHour() < 13
                ? LocalDateTime.of(meeting.toLocalDate(), LocalTime.of(17, 0, 0))
                : LocalDateTime.of(meeting.toLocalDate(), LocalTime.of(13, 0, 0)).plusDays(1);
    }

    private static LocalDateTime getEndOfWeek(LocalDateTime meeting) {
        return switch (meeting.getDayOfWeek()) {
            case DayOfWeek.MONDAY, DayOfWeek.WEDNESDAY, DayOfWeek.TUESDAY -> nextDay(meeting, DayOfWeek.FRIDAY, 17);
            default -> nextDay(meeting, DayOfWeek.SUNDAY, 20);
        };
    }

    private static LocalDateTime getMonth(LocalDateTime meeting, String description) {
        int month = Integer.parseInt(description.substring(0, description.length() - 1));
        int year = meeting.getMonth().getValue() < month ? meeting.getYear() : meeting.getYear() + 1;
        var date = LocalDateTime.of(year, month, 1, 8, 0, 0);

        while (date.getDayOfWeek() == DayOfWeek.SUNDAY || date.getDayOfWeek() == DayOfWeek.SATURDAY) {
            date = date.plusDays(1);
        }

        return date;
    }

    private static LocalDateTime getQuarter(LocalDateTime meeting, String description) {
        int quarter = Integer.parseInt(description.substring(1));
        int meetingQuarter = ((meeting.getMonth().getValue() - 1) / 3) + 1;
        int year = meetingQuarter <= quarter ? meeting.getYear() : meeting.getYear() + 1;
        int lastMonth = quarter * 3;

        var date = LocalDateTime.of(year, lastMonth, YearMonth.of(year, lastMonth).lengthOfMonth(), 8, 0, 0);

        while (date.getDayOfWeek() == DayOfWeek.SUNDAY || date.getDayOfWeek() == DayOfWeek.SATURDAY) {
            date = date.minusDays(1);
        }

        return date;
    }

    private static LocalDateTime nextDay(LocalDateTime current, DayOfWeek target, int hour) {
        int days = (target.getValue() - current.getDayOfWeek().getValue() + 7) % 7;

        return LocalDateTime.of(current.toLocalDate(), LocalTime.of(hour, 0)).plusDays(days);
    }
}
