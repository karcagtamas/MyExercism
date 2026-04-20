import java.time.DayOfWeek
import java.time.LocalDate

class Meetup(private val month: Int, private val year: Int) {

    fun day(dayOfWeek: DayOfWeek, schedule: MeetupSchedule): LocalDate {
        val firstDay = LocalDate.of(year, month, 1)

        val dates = generateSequence(firstDay) { it.plusDays(1) }
            .takeWhile { it.monthValue == month }
            .filter { it.dayOfWeek == dayOfWeek }
            .toList()

        return when (schedule) {
            MeetupSchedule.FIRST -> dates[0]
            MeetupSchedule.SECOND -> dates[1]
            MeetupSchedule.THIRD -> dates[2]
            MeetupSchedule.FOURTH -> dates[3]
            MeetupSchedule.LAST -> dates.last()
            MeetupSchedule.TEENTH -> dates.first { it.dayOfMonth in 13..19 }
        }
    }
}
