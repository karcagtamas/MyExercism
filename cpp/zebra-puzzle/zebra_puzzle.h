#pragma once

#include <string>
#include <array>

namespace zebra_puzzle
{

    enum Color
    {
        red,
        green,
        ivory,
        yellow,
        blue
    };
    enum Nationality
    {
        englishman,
        spaniard,
        ukrainian,
        norwegian,
        japanese
    };
    enum Pet
    {
        dog,
        snails,
        fox,
        horse,
        zebra
    };
    enum Drink
    {
        coffee,
        tea,
        milk,
        orange_juice,
        water
    };
    enum Hobby
    {
        dancing,
        painting,
        reading,
        football,
        chess
    };

    struct State
    {
        std::array<int, 5> color{};
        std::array<int, 5> nationality{};
        std::array<int, 5> pet{};
        std::array<int, 5> drink{};
        std::array<int, 5> hobby{};
    };

    struct Solution
    {
        std::string drinksWater;
        std::string ownsZebra;
    };

    Solution solve();

} // namespace zebra_puzzle
