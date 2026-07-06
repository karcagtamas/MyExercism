#include "rail_fence_cipher.h"
#include <vector>

namespace rail_fence_cipher
{

    std::string encode(const std::string &plaintext, int num_rails)
    {

        if (num_rails == 0)
            return plaintext;

        std::vector<std::string> rows(num_rails);
        int rail = 0;
        int direction = 1;

        for (auto c : plaintext)
        {
            rows[rail] += c;

            if (rail == 0)
            {
                direction = 1;
            }
            else if (rail == num_rails - 1)
            {
                direction = -1;
            }

            rail += direction;
        }

        std::string result;
        for (const auto &r : rows)
            result += r;

        return result;
    }

    std::string decode(const std::string &ciphertext, int num_rails)
    {
        if (num_rails == 0)
            return ciphertext;

        std::vector<int> pattern(static_cast<int>(ciphertext.size()));
        int rail = 0;
        int direction = 1;

        for (std::size_t i = 0; i < ciphertext.size(); i++)
        {
            pattern[i] = rail;

            if (rail == 0)
            {
                direction = 1;
            }
            else if (rail == num_rails - 1)
            {
                direction = -1;
            }

            rail += direction;
        }

        std::vector<int> counts(num_rails);
        for (auto r : pattern)
        {
            counts[r]++;
        }

        std::vector<std::vector<char>> rail_chars(num_rails);
        for (int i = 0; i < num_rails; i++)
        {
            rail_chars[i] = std::vector<char>(counts[i]);
        }

        int index = 0;
        for (int r = 0; r < num_rails; r++)
        {
            for (std::size_t i = 0; i < rail_chars[r].size(); i++)
            {
                rail_chars[r][i] = ciphertext[index++];
            }
        }

        std::vector<int> rail_indices(num_rails);
        std::string result{};

        for (auto r : pattern)
        {
            result += rail_chars[r][rail_indices[r]++];
        }

        return result;
    }

} // namespace rail_fence_cipher
