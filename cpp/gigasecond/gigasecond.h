#pragma once
#include <chrono>

namespace gigasecond
{

    std::chrono::system_clock::time_point advance(std::chrono::system_clock::time_point tp);

} // namespace gigasecond
