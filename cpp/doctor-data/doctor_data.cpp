#include "doctor_data.h"

heaven::Vessel::Vessel(const std::string &name, int generation) : name(name), generation(generation), current_system(star_map::System::Sol) {}

heaven::Vessel::Vessel(const std::string &name, int generation, star_map::System current_system) : name(name), generation(generation), current_system(current_system) {}

heaven::Vessel heaven::Vessel::replicate(const std::string &name)
{
    return Vessel(name, generation + 1, current_system);
}

void heaven::Vessel::make_buster()
{
    busters++;
}

bool heaven::Vessel::shoot_buster()
{
    if (busters <= 0)
    {
        return false;
    }

    busters--;
    return true;
}

const std::string &heaven::get_older_bob(const Vessel &v1, const Vessel &v2)
{
    if (v1.generation <= v2.generation)
    {
        return v1.name;
    }

    return v2.name;
}

bool heaven::in_the_same_system(const Vessel &v1, const Vessel &v2)
{
    return v1.current_system == v2.current_system;
}