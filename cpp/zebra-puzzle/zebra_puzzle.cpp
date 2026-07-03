#include "zebra_puzzle.h"
#include <algorithm>

namespace zebra_puzzle
{

    static bool solve(State &s)
    {
        std::array<int, 5> color{0, 1, 2, 3, 4};

        do
        {
            s.color = color;

            if (color[green] != color[ivory] + 1)
                continue;

            std::array<int, 5> nat{0, 1, 2, 3, 4};

            do
            {
                s.nationality = nat;

                if (nat[norwegian] != 0)
                    continue;

                if (nat[englishman] != color[red])
                    continue;

                if (std::abs(nat[norwegian] - color[blue]) != 1)
                    continue;

                std::array<int, 5> drink{0, 1, 2, 3, 4};

                do
                {
                    s.drink = drink;

                    if (drink[milk] != 2)
                        continue;

                    if (color[green] != drink[coffee])
                        continue;

                    if (nat[ukrainian] != drink[tea])
                        continue;

                    std::array<int, 5> hobby{0, 1, 2, 3, 4};

                    do
                    {
                        s.hobby = hobby;

                        if (color[yellow] != hobby[painting])
                            continue;

                        if (hobby[football] != drink[orange_juice])
                            continue;

                        if (nat[japanese] != hobby[chess])
                            continue;

                        std::array<int, 5> pet{0, 1, 2, 3, 4};

                        do
                        {
                            s.pet = pet;

                            if (nat[spaniard] != pet[dog])
                                continue;

                            if (std::abs(hobby[reading] - pet[fox]) != 1)
                                continue;

                            if (std::abs(hobby[painting] - pet[horse]) != 1)
                                continue;

                            return true;
                        } while (std::next_permutation(pet.begin(), pet.end()));
                    } while (std::next_permutation(hobby.begin(), hobby.end()));
                } while (std::next_permutation(drink.begin(), drink.end()));
            } while (std::next_permutation(nat.begin(), nat.end()));
        } while (std::next_permutation(color.begin(), color.end()));

        return false;
    }

    Solution solve()
    {
        State s{};
        solve(s);
        Solution out{};

        for (int i = 0; i < 5; i++)
        {
            if (s.drink[i] == water)
            {
                out.drinksWater = (i == 0 ? "Norwegian" : i == 1 ? "Englishman"
                                                      : i == 2   ? "Spaniard"
                                                      : i == 3   ? "Ukrainian"
                                                                 : "Japanese");
            }

            if (s.pet[i] == zebra)
                out.ownsZebra = (i == 0 ? "Norwegian" : i == 1 ? "Englishman"
                                                    : i == 2   ? "Spaniard"
                                                    : i == 3   ? "Ukrainian"
                                                               : "Japanese");
        }

        return out;
    }

} // namespace zebra_puzzle
