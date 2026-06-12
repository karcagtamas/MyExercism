#include "power_of_troy.h"

namespace troy
{
    void give_new_artifact(human &h, const std::string &name)
    {
        h.possession = std::make_unique<artifact>(name);
    }

    void exchange_artifacts(std::unique_ptr<artifact> &a, std::unique_ptr<artifact> &b)
    {
        std::swap(a, b);
    }

    void manifest_power(human &h, const std::string &effect)
    {
        h.own_power = std::make_shared<power>(effect);
    }

    void use_power(human &caster, human &target)
    {
        target.influenced_by = caster.own_power;
    }

    int power_intensity(const human &h)
    {
        if (!h.own_power)
        {
            return 0;
        }

        return static_cast<int>(h.own_power.use_count());
    }
} // namespace troy
