#include "yacht.h"
#include <array>
#include <algorithm>

namespace yacht
{
    static int four_of_a_kind(const std::array<int, 7> &counts)
    {
        int max = 0;

        for (int i = 6; i >= 1; --i)
        {
            if (counts[i] >= 4)
            {
                max = std::max(max, i * 4);
            }
        }

        return max;
    }

    static bool contains_full_house(const std::array<int, 7> &counts)
    {
        bool has3 = false;
        bool has2 = false;

        for (int c : counts)
        {
            if (c == 3)
                has3 = true;
            else if (c == 2)
                has2 = true;
        }

        return has3 && has2;
    }

    static bool counts_matches(const std::array<int, 7> &counts, std::initializer_list<int> faces)
    {
        for (int face : faces)
        {
            if (counts[face] != 1)
                return false;
        }

        return true;
    }

    int score(const std::vector<int> &dice, const std::string &category)
    {
        std::array<int, 7> counts{};
        int sum = 0;

        for (auto d : dice)
        {
            counts[d]++;
            sum += d;
        }

        if (category == "yacht")
        {
            return std::find(counts.begin(), counts.end(), 5) != counts.end() ? 50 : 0;
        }
        else if (category == "ones")
        {
            return counts[1];
        }
        else if (category == "twos")
        {
            return counts[2] * 2;
        }
        else if (category == "threes")
        {
            return counts[3] * 3;
        }
        else if (category == "fours")
        {
            return counts[4] * 4;
        }
        else if (category == "fives")
        {
            return counts[5] * 5;
        }
        else if (category == "sixes")
        {
            return counts[6] * 6;
        }
        else if (category == "full house")
        {
            return contains_full_house(counts) ? sum : 0;
        }
        else if (category == "four of a kind")
        {
            return four_of_a_kind(counts);
        }
        else if (category == "little straight")
        {
            return counts_matches(counts, {1, 2, 3, 4, 5}) ? 30 : 0;
        }
        else if (category == "big straight")
        {
            return counts_matches(counts, {2, 3, 4, 5, 6}) ? 30 : 0;
        }
        else if (category == "choice")
        {
            return sum;
        }

        return 0;
    }

} // namespace yacht
