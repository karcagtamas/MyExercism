#include "food_chain.h"
#include <vector>

namespace food_chain
{

    std::string verse(int number)
    {
        const std::vector<std::string> animals{
            "fly",
            "spider",
            "bird",
            "cat",
            "dog",
            "goat",
            "cow",
            "horse"};

        const std::vector<std::string> extra{
            "",
            "It wriggled and jiggled and tickled inside her.\n",
            "How absurd to swallow a bird!\n",
            "Imagine that, to swallow a cat!\n",
            "What a hog, to swallow a dog!\n",
            "Just opened her throat and swallowed a goat!\n",
            "I don't know how she swallowed a cow!\n",
            "She's dead, of course!\n"};

        int index = number - 1;
        std::string result;

        result += "I know an old lady who swallowed a " + animals[index] + ".\n";

        if (animals[index] == "horse")
        {
            result += extra[index];
            return result;
        }

        result += extra[index];

        for (int i = index; i > 0; --i)
        {
            result += "She swallowed the " + animals[i] + " to catch the " + animals[i - 1];

            if (animals[i - 1] == "spider")
            {
                result += " that wriggled and jiggled and tickled inside her";
            }

            result += ".\n";
        }

        result += "I don't know why she swallowed the fly. Perhaps she'll die.\n";

        return result;
    }

    std::string verses(int start, int end)
    {
        std::string result;

        for (int i = start; i <= end; ++i)
        {
            result += verse(i);
            result += "\n";
        }

        return result;
    }

    std::string sing()
    {
        return verses(1, 8);
    }

} // namespace food_chain
