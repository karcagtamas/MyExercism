import java.time.LocalDate
import java.time.LocalDateTime
import java.time.LocalTime

class Gigasecond(private val baseDateTime: LocalDateTime) {

    constructor(baseDate: LocalDate) : this(LocalDateTime.of(baseDate, LocalTime.MIN))

    val date: LocalDateTime = baseDateTime.plusSeconds(1_000_000_000)
}
