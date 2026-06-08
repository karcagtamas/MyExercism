#pragma once
#include <string>
#include <array>

namespace kindergarten_garden
{

    enum Plants
    {
        clover,
        grass,
        violets,
        radishes
    };

    std::array<Plants, 4> plants(const std::string &plants, const std::string &student);

} // namespace kindergarten_garden
