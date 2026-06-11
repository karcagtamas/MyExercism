#pragma once
#include <string>

namespace star_map
{
    enum System
    {
        AlphaCentauri,
        BetaHydri,
        DeltaEridani,
        EpsilonEridani,
        Omicron2Eridani,
        Sol
    };
}

namespace heaven
{
    class Vessel
    {
    public:
        std::string name;
        int generation;
        star_map::System current_system;
        int busters = 0;

        Vessel(const std::string &name, int generation);
        Vessel(const std::string &name, int generation, star_map::System current_system);

        Vessel replicate(const std::string &name);
        void make_buster();
        bool shoot_buster();
    };

    const std::string &get_older_bob(const Vessel &v1, const Vessel &v2);

    bool in_the_same_system(const Vessel &v1, const Vessel &v2);
}
