#include "gigasecond.h"

namespace gigasecond
{

    std::chrono::system_clock::time_point advance(std::chrono::system_clock::time_point tp)
    {
        return tp + std::chrono::seconds{1'000'000'000};
    }

} // namespace gigasecond
