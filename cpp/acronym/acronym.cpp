#include "acronym.h"

namespace acronym
{

    std::string acronym(const std::string &phrase)
    {
        std::string result;
        bool new_word = true;

        for (char c : phrase)
        {
            unsigned char uc = static_cast<unsigned char>(c);

            if (c == '-')
            {
                new_word = true;
            }
            else if (std::isspace(uc))
            {
                new_word = true;
            }
            else if (std::isalpha(uc))
            {
                if (new_word)
                {
                    result += static_cast<char>(std::toupper(uc));
                }

                new_word = false;
            }
            else if (std::isdigit(uc))
            {
                new_word = false;
            }
        }

        return result;
    }

} // namespace acronym
