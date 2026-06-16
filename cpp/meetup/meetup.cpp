#include "meetup.h"

namespace meetup
{

    scheduler::scheduler(boost::gregorian::date::month_type m, int y) : month(m), year(y)
    {
    }

    boost::gregorian::date scheduler::nth_weekday(boost::gregorian::greg_weekday weekday, int occurrence) const
    {
        boost::gregorian::date first(year, month, 1);

        int offset = (weekday.as_number() - first.day_of_week().as_number() + 7) % 7;

        return first + boost::gregorian::days(offset + (occurrence - 1) * 7);
    }

    boost::gregorian::date scheduler::teenth(boost::gregorian::greg_weekday weekday) const
    {
        for (int day = 13; day <= 19; ++day)
        {
            boost::gregorian::date current(year, month, day);

            if (current.day_of_week() == weekday)
            {
                return current;
            }
        }

        return boost::gregorian::date();
    }

    boost::gregorian::date scheduler::last_weekday(boost::gregorian::greg_weekday weekday) const
    {
        boost::gregorian::date current(year, month, boost::gregorian::gregorian_calendar::end_of_month_day(year, month));

        while (current.day_of_week() != weekday)
        {
            current -= boost::gregorian::days(1);
        }

        return current;
    }

    boost::gregorian::date scheduler::monteenth() const
    {
        return teenth(boost::gregorian::Monday);
    }

    boost::gregorian::date scheduler::tuesteenth() const
    {
        return teenth(boost::gregorian::Tuesday);
    }

    boost::gregorian::date scheduler::wednesteenth() const
    {
        return teenth(boost::gregorian::Wednesday);
    }

    boost::gregorian::date scheduler::thursteenth() const
    {
        return teenth(boost::gregorian::Thursday);
    }

    boost::gregorian::date scheduler::friteenth() const
    {
        return teenth(boost::gregorian::Friday);
    }

    boost::gregorian::date scheduler::saturteenth() const
    {
        return teenth(boost::gregorian::Saturday);
    }

    boost::gregorian::date scheduler::sunteenth() const
    {
        return teenth(boost::gregorian::Sunday);
    }

    boost::gregorian::date scheduler::first_monday() const
    {
        return nth_weekday(boost::gregorian::Monday, 1);
    }

    boost::gregorian::date scheduler::first_tuesday() const
    {
        return nth_weekday(boost::gregorian::Tuesday, 1);
    }

    boost::gregorian::date scheduler::first_wednesday() const
    {
        return nth_weekday(boost::gregorian::Wednesday, 1);
    }

    boost::gregorian::date scheduler::first_thursday() const
    {
        return nth_weekday(boost::gregorian::Thursday, 1);
    }

    boost::gregorian::date scheduler::first_friday() const
    {
        return nth_weekday(boost::gregorian::Friday, 1);
    }

    boost::gregorian::date scheduler::first_saturday() const
    {
        return nth_weekday(boost::gregorian::Saturday, 1);
    }

    boost::gregorian::date scheduler::first_sunday() const
    {
        return nth_weekday(boost::gregorian::Sunday, 1);
    }

    boost::gregorian::date scheduler::second_monday() const
    {
        return nth_weekday(boost::gregorian::Monday, 2);
    }

    boost::gregorian::date scheduler::second_tuesday() const
    {
        return nth_weekday(boost::gregorian::Tuesday, 2);
    }

    boost::gregorian::date scheduler::second_wednesday() const
    {
        return nth_weekday(boost::gregorian::Wednesday, 2);
    }

    boost::gregorian::date scheduler::second_thursday() const
    {
        return nth_weekday(boost::gregorian::Thursday, 2);
    }

    boost::gregorian::date scheduler::second_friday() const
    {
        return nth_weekday(boost::gregorian::Friday, 2);
    }

    boost::gregorian::date scheduler::second_saturday() const
    {
        return nth_weekday(boost::gregorian::Saturday, 2);
    }

    boost::gregorian::date scheduler::second_sunday() const
    {
        return nth_weekday(boost::gregorian::Sunday, 2);
    }

    boost::gregorian::date scheduler::third_monday() const
    {
        return nth_weekday(boost::gregorian::Monday, 3);
    }

    boost::gregorian::date scheduler::third_tuesday() const
    {
        return nth_weekday(boost::gregorian::Tuesday, 3);
    }

    boost::gregorian::date scheduler::third_wednesday() const
    {
        return nth_weekday(boost::gregorian::Wednesday, 3);
    }

    boost::gregorian::date scheduler::third_thursday() const
    {
        return nth_weekday(boost::gregorian::Thursday, 3);
    }

    boost::gregorian::date scheduler::third_friday() const
    {
        return nth_weekday(boost::gregorian::Friday, 3);
    }

    boost::gregorian::date scheduler::third_saturday() const
    {
        return nth_weekday(boost::gregorian::Saturday, 3);
    }

    boost::gregorian::date scheduler::third_sunday() const
    {
        return nth_weekday(boost::gregorian::Sunday, 3);
    }

    boost::gregorian::date scheduler::fourth_monday() const
    {
        return nth_weekday(boost::gregorian::Monday, 4);
    }

    boost::gregorian::date scheduler::fourth_tuesday() const
    {
        return nth_weekday(boost::gregorian::Tuesday, 4);
    }

    boost::gregorian::date scheduler::fourth_wednesday() const
    {
        return nth_weekday(boost::gregorian::Wednesday, 4);
    }

    boost::gregorian::date scheduler::fourth_thursday() const
    {
        return nth_weekday(boost::gregorian::Thursday, 4);
    }

    boost::gregorian::date scheduler::fourth_friday() const
    {
        return nth_weekday(boost::gregorian::Friday, 4);
    }

    boost::gregorian::date scheduler::fourth_saturday() const
    {
        return nth_weekday(boost::gregorian::Saturday, 4);
    }

    boost::gregorian::date scheduler::fourth_sunday() const
    {
        return nth_weekday(boost::gregorian::Sunday, 4);
    }

    boost::gregorian::date scheduler::last_monday() const
    {
        return last_weekday(boost::gregorian::Monday);
    }

    boost::gregorian::date scheduler::last_tuesday() const
    {
        return last_weekday(boost::gregorian::Tuesday);
    }

    boost::gregorian::date scheduler::last_wednesday() const
    {
        return last_weekday(boost::gregorian::Wednesday);
    }

    boost::gregorian::date scheduler::last_thursday() const
    {
        return last_weekday(boost::gregorian::Thursday);
    }

    boost::gregorian::date scheduler::last_friday() const
    {
        return last_weekday(boost::gregorian::Friday);
    }

    boost::gregorian::date scheduler::last_saturday() const
    {
        return last_weekday(boost::gregorian::Saturday);
    }

    boost::gregorian::date scheduler::last_sunday() const
    {
        return last_weekday(boost::gregorian::Sunday);
    }

} // namespace meetup
