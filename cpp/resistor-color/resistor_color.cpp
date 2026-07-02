#include "resistor_color.h"

namespace resistor_color
{
    std::vector<std::string> colors()
    {
        return {"black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"};
    }

    int color_code(const std::string &color)
    {
        std::vector<std::string> all = colors();
        for (size_t i = 0; i < all.size(); i++)
        {
            if (all[i] == color)
                return i;
        }

        return -1;
    }

} // namespace resistor_color
