#include "rotational_cipher.h"

namespace rotational_cipher
{

    char rotate(const char c, int shift)
    {
        if (c >= 'a' && c <= 'z')
        {
            return (char)(((c - 'a' + shift) % 26) + 'a');
        }
        else if (c >= 'A' && c <= 'Z')
        {
            return (char)(((c - 'A' + shift) % 26) + 'A');
        }

        return c;
    }

    std::string rotate(const std::string &text, int shift)
    {
        std::string result;

        for (auto i : text)
        {
            result += rotate(i, shift);
        }

        return result;
    }

} // namespace rotational_cipher
