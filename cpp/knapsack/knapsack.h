#pragma once

#include <vector>

namespace knapsack
{

    struct Item
    {
        int weight;
        int value;
    };

    int maximum_value(int max_weight, const std::vector<knapsack::Item> &items);

} // namespace knapsack
