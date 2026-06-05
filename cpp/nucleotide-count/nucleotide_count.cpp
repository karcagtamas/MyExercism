#include "nucleotide_count.h"
#include <stdexcept>

namespace nucleotide_count
{
    std::map<char, int> count(const std::string &sequence)
    {
        std::map<char, int> counts = {
            {'A', 0},
            {'C', 0},
            {'G', 0},
            {'T', 0},
        };

        for (size_t i = 0; i < sequence.length(); i++)
        {
            if (counts.find(sequence[i]) == counts.end())
            {
                throw std::invalid_argument("Invalid key");
            }

            counts.at(sequence[i])++;
        }

        return counts;
    }
} // namespace nucleotide_count
