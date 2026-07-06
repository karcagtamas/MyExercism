#pragma once

#include <unordered_map>
#include <vector>
#include <string_view>

namespace parallel_letter_frequency
{

    std::unordered_map<char, int> frequency(const std::vector<std::string_view> &texts);

}
