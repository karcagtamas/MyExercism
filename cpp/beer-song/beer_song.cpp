#include "beer_song.h"

namespace beer_song
{

    std::string verse(int n)
    {
        int next = n - 1;

        if (next >= 0)
        {
            std::string word = n > 1 ? "bottles" : "bottle";
            std::string result = std::to_string(n) + " " + word + " of beer on the wall, " + std::to_string(n) + " " + word + " of beer.\n";

            if (next == 0)
            {
                result += "Take it down and pass it around, no more bottles of beer on the wall.\n";
            }
            else
            {
                std::string next_word = next > 1 ? "bottles" : "bottle";
                result += "Take one down and pass it around, " + std::to_string(next) + " " + next_word + " of beer on the wall.\n";
            }

            return result;
        }

        return "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n";
    }

    std::string sing(int from, int to)
    {
        std::string result;
        for (int i = from; i >= to; i--)
        {
            std::string v = verse(i);

            if (!result.empty())
            {
                result += "\n";
            }

            result += v;
        }

        return result;
    }

    std::string sing(int from)
    {
        return sing(from, 0);
    }

} // namespace beer_song
