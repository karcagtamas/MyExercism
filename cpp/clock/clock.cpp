#include "clock.h"

namespace date_independent
{

    clock clock::at(int hour, int minute)
    {
        return clock(hour * 60 + minute);
    }

    clock::clock(int minutes) : minutes_since_midnight(normalize(minutes))
    {
    }

    int clock::normalize(int minutes)
    {
        constexpr int minutes_per_day = 24 * 60;

        minutes %= minutes_per_day;

        while (minutes < 0)
        {
            minutes += minutes_per_day;
        }

        return minutes;
    }

    clock clock::plus(int minutes) const
    {
        return clock(minutes_since_midnight + minutes);
    }

    clock clock::substract(int minutes) const
    {
        return clock(minutes_since_midnight - minutes);
    }

    bool clock::operator==(const clock &other) const
    {
        return minutes_since_midnight == other.minutes_since_midnight;
    }

    bool clock::operator!=(const clock &other) const
    {
        return !(*this == other);
    }

    clock::operator std::string() const
    {
        const int hour = minutes_since_midnight / 60;
        const int minute = minutes_since_midnight % 60;

        std::string result;

        if (hour < 10)
        {
            result += '0';
        }

        result += std::to_string(hour);
        result += ':';

        if (minute < 10)
        {
            result += '0';
        }

        result += std::to_string(minute);

        return result;
    }

} // namespace date_independent
