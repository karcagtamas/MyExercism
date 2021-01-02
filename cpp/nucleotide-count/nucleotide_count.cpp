#include "nucleotide_count.h"
#include <stdexcept>

namespace nucleotide_count
{
    void counter::calc()
    {
        for (size_t i = 0; i < dna.length(); i++)
        {
            if (nuc.find(dna[i]) == nuc.end())
            {
                throw std::invalid_argument("Invalid nuc key");
            }
            nuc.at(dna[i])++;
        }
    }

    std::map<char, int> counter::nucleotide_counts() const
    {
        return nuc;
    }

    int counter::count(char v) const
    {
        if (nuc.find(v) == nuc.end())
        {
            throw std::invalid_argument("Invalid nuc key");
        }
        return nuc.at(v);
    }
} // namespace nucleotide_count
