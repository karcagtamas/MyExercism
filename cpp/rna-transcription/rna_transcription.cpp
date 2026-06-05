#include "rna_transcription.h"
#include <stdexcept>

namespace rna_transcription
{
    char to_rna(const char c)
    {
        switch (c)
        {
        case 'G':
            return 'C';
            break;
        case 'C':
            return 'G';
            break;
        case 'T':
            return 'A';
            break;
        case 'A':
            return 'U';
            break;

        default:
            throw std::invalid_argument("Invalid character");
            break;
        }
    }

    std::string to_rna(const std::string &sequence)
    {
        std::string result;

        for (size_t i = 0; i < sequence.length(); i++)
        {
            result += to_rna(sequence[i]);
        }

        return result;
    }

} // namespace rna_transcription
