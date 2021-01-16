#if !defined(SPACE_AGE_H)
#define SPACE_AGE_H

namespace space_age
{
    class space_age
    {
    private:
        long int secs;
        const double mercury = 0.2408467;
        const double venus = 0.61519726;
        const double mars = 1.8808158;
        const double jupiter = 11.862615;
        const double saturn = 29.447498;
        const double uranus = 84.016846;
        const double neptune = 164.79132;
        double getAge(double param) const;

    public:
        space_age(long int secs) : secs(secs){};
        long int seconds() const;
        double on_earth() const;
        double on_mercury() const;
        double on_venus() const;
        double on_mars() const;
        double on_jupiter() const;
        double on_saturn() const;
        double on_uranus() const;
        double on_neptune() const;
    };
} // namespace space_age

#endif // SPACE_AGE_H