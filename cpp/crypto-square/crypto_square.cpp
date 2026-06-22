#include "crypto_square.h"
#include <vector>
#include <sstream>

namespace crypto_square
{

    cipher::cipher(const std::string &text) : text(text) {}

    std::string cipher::normalized_cipher_text()
    {
        std::string normalized;

        for (char c : text)
        {
            if (std::isalpha(static_cast<unsigned char>(c)) || std::isdigit(static_cast<unsigned char>(c)))
            {
                normalized += static_cast<char>(std::tolower(static_cast<unsigned char>(c)));
            }
        }

        auto [r, c] = rectangle(normalized);

        std::vector<std::string> result;

        for (int i = 0; i < c; i++)
        {
            std::string sb;

            for (int j = 0; j < r; j++)
            {
                int index = j * c + i;

                if (index < static_cast<int>(normalized.length()))
                {
                    sb += normalized[index];
                }
                else
                {
                    sb += ' ';
                }
            }

            result.push_back(sb);
        }

        std::ostringstream output;

        for (size_t i = 0; i < result.size(); i++)
        {
            if (i > 0)
                output << ' ';

            output << result[i];
        }

        return output.str();
    }

    std::pair<int, int> cipher::rectangle(const std::string &normalized)
    {
        int n = static_cast<int>(normalized.length());

        int r = 1;
        int c = n;

        for (int i = 1; i <= n; i++)
        {
            int rows = i;
            int cols = (n + rows - 1) / rows;

            if (cols >= rows && cols - rows <= 1)
            {
                r = rows;
                c = cols;
                break;
            }
        }

        return {r, c};
    }

} // namespace crypto_square
