#include "dnd_character.h"
#include <algorithm>
#include <random>
#include <cmath>

namespace dnd_character
{
    static std::mt19937 &rng()
    {
        static std::mt19937 gen{std::random_device{}()};
        return gen;
    }

    static int roll_4d6_drop_lowest()
    {
        std::uniform_int_distribution<int> dist(1, 6);

        std::vector<int> dice(4);
        for (int &d : dice)
            d = dist(rng());

        std::sort(dice.begin(), dice.end(), std::greater<int>());

        return dice[0] + dice[1] + dice[2];
    }

    int ability()
    {
        return roll_4d6_drop_lowest();
    }

    int modifier(int score)
    {
        return (int)std::floor((score - 10) / 2.0);
    }

    Character::Character() : strength(ability()),
                             dexterity(ability()),
                             constitution(ability()),
                             intelligence(ability()),
                             wisdom(ability()),
                             charisma(ability()),
                             hitpoints(10 + modifier(constitution))
    {
    }

} // namespace dnd_character
