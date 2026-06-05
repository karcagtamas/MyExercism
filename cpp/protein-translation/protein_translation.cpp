#include "protein_translation.h"
#include <stdexcept>

namespace protein_translation
{

    std::vector<std::string> proteins(const std::string &sequence)
    {
        if (sequence.length() % 3 != 0)
        {
            throw std::invalid_argument("Invalid sequence");
        }

        std::vector<std::string> result;

        for (size_t i = 0; i < sequence.length(); i += 3)
        {
            auto v = sequence.substr(i, 3);

            if (v == "AUG")
                result.push_back("Methionine");
            else if (v == "UUU" || v == "UUC")
                result.push_back("Phenylalanine");
            else if (v == "UUA" || v == "UUG")
                result.push_back("Leucine");
            else if (v == "UCU" || v == "UCC" || v == "UCA" || v == "UCG")
                result.push_back("Serine");
            else if (v == "UAU" || v == "UAC")
                result.push_back("Tyrosine");
            else if (v == "UGU" || v == "UGC")
                result.push_back("Cysteine");
            else if (v == "UGG")
                result.push_back("Tryptophan");
            else if (v == "UAA" || v == "UAG" || v == "UGA")
            {
                // result.push_back("STOP");
                break;
            }
            else
                throw std::invalid_argument("Invalid sequence part");
        }

        return result;
    }

} // namespace protein_translation
