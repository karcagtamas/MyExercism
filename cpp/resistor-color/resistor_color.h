#pragma once

#include <vector>
#include <string>

namespace resistor_color
{

    std::vector<std::string> colors();
    
    int color_code(const std::string &color);

} // namespace resistor_color
