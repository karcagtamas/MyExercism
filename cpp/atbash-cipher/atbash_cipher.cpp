#include "atbash_cipher.h"

namespace atbash_cipher
{
    static std::string translate(const std::string &s)
    {
        std::string result;

        for (unsigned char ch : s)
        {
            ch = std::tolower(ch);

            if (std::isalnum(ch))
            {
                if (std::isalpha(ch))
                {
                    result += static_cast<char>('z' - (ch - 'a'));
                }
                else
                {
                    result += ch;
                }
            }
        }

        return result;
    }

    std::string encode(const std::string &plainValue)
    {
        std::string translated = translate(plainValue);
        std::string result;

        for (size_t i = 0; i < translated.size(); ++i)
        {
            if (i > 0 && i % 5 == 0)
            {
                result += ' ';
            }

            result += translated[i];
        }

        return result;
    }

    std::string decode(const std::string &cipher)
    {
        return translate(cipher);
    }

} // namespace atbash_cipher
