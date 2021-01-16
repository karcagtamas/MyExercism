#include "space_age.h"

namespace space_age
{
    double space_age::getAge(double param) const
    {
        return on_earth() / param;
    }
    long int space_age::seconds() const
    {
        return secs;
    }
    double space_age::on_earth() const
    {
        return secs / (double)31557600;
    }
    double space_age::on_mercury() const
    {
        return getAge(mercury);
    }
    double space_age::on_venus() const
    {
        return getAge(venus);
    }
    double space_age::on_mars() const
    {
        return getAge(mars);
    }
    double space_age::on_jupiter() const
    {
        return getAge(jupiter);
    }
    double space_age::on_saturn() const
    {
        return getAge(saturn);
    }
    double space_age::on_uranus() const
    {
        return getAge(uranus);
    }
    double space_age::on_neptune() const
    {
        return getAge(neptune);
    }

} // namespace space_age
