#include "series.h"
#include <stdexcept>

namespace series
{

    std::vector<std::string> slice(const std::string &numbers, int slice_length)
    {
        if (slice_length <= 0 || (int)numbers.size() < slice_length)
        {
            throw std::domain_error("Invalid slice length");
        }

        int count = numbers.size() - (int)slice_length + 1;
        std::vector<std::string> result;

        for (int i = 0; i < count; i++)
        {
            result.push_back(numbers.substr(i, slice_length));
        }
        return result;
    }

} // namespace series
