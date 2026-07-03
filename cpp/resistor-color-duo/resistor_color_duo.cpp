#include "resistor_color_duo.h"
#include <cmath>

namespace resistor_color_duo
{
    static int value(const std::string &color)
    {
        static std::vector<std::string> COLORS = {"black",
                                                  "brown",
                                                  "red",
                                                  "orange",
                                                  "yellow",
                                                  "green",
                                                  "blue",
                                                  "violet",
                                                  "grey",
                                                  "white"};

        for (size_t i = 0; i < COLORS.size(); i++)
        {
            if (COLORS[i] == color)
            {
                return i;
            }
        }

        return -1;
    }

    int value(const std::vector<std::string> colors)
    {

        int sum = 0;
        size_t size = 2;

        for (size_t i = 0; i < size; i++)
        {
            int index = value(colors[i]);

            sum += index * pow(10.0, size - i - 1);
        }

        return sum;
    }

} // namespace resistor_color_duo
