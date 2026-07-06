#include "twelve_days.h"
#include <vector>

namespace twelve_days
{
    static const std::vector<std::string> DAYS = {
        "first",
        "second",
        "third",
        "fourth",
        "fifth",
        "sixth",
        "seventh",
        "eighth",
        "ninth",
        "tenth",
        "eleventh",
        "twelfth",
    };

    static const std::vector<std::string> GIFTS = {
        "a Partridge in a Pear Tree",
        "two Turtle Doves",
        "three French Hens",
        "four Calling Birds",
        "five Gold Rings",
        "six Geese-a-Laying",
        "seven Swans-a-Swimming",
        "eight Maids-a-Milking",
        "nine Ladies Dancing",
        "ten Lords-a-Leaping",
        "eleven Pipers Piping",
        "twelve Drummers Drumming",
    };

    std::string verse(int verse_number)
    {
        std::string result{};

        result += "On the " + DAYS[verse_number - 1] + " day of Christmas my true love gave to me: ";

        for (int i = verse_number - 1; i >= 0; i--)
        {
            if (i == 0 && verse_number > 1)
            {
                result += "and ";
            }

            result += GIFTS[i];

            if (i > 0)
            {
                result += ", ";
            }
        }

        result += ".\n";

        return result;
    }

    std::string recite(int start_verse, int end_verse)
    {
        std::string result{};

        for (int i = start_verse; i <= end_verse; i++)
        {
            result += verse(i);

            if (i != end_verse)
            {
                result += "\n";
            }
        }

        return result;
    }

} // namespace twelve_days
