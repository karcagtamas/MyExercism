#pragma once

#include <string>
#include <memory>
#include <utility>

namespace troy
{

    struct artifact
    {
        // constructors needed (until C++20)
        artifact(std::string name) : name(name) {}
        std::string name;
    };

    struct power
    {
        // constructors needed (until C++20)
        power(std::string effect) : effect(effect) {}
        std::string effect;
    };

    struct human
    {
        std::unique_ptr<artifact> possession;
        std::shared_ptr<power> own_power;
        std::shared_ptr<power> influenced_by;
    };

    void give_new_artifact(human &h, const std::string &name);

    void exchange_artifacts(std::unique_ptr<artifact> &a, std::unique_ptr<artifact> &b);

    void manifest_power(human &h, const std::string &effect);

    void use_power(human &caster, human &target);

    int power_intensity(const human &h);

} // namespace troy
