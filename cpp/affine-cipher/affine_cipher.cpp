#include "affine_cipher.h"

#include <cctype>
#include <numeric>
#include <stdexcept>

namespace affine_cipher
{
    static int mod_inverse(int a, int m)
    {
        a %= m;
        for (int x = 1; x < m; ++x)
        {
            if ((a * x) % m == 1)
                return x;
        }
        return -1;
    }

    static bool coprime(int a, int m)
    {
        return std::gcd(a, m) == 1;
    }

    static char encode_char(char c, int a, int b)
    {
        if (std::isdigit(c))
            return c;

        int x = c - 'a';
        return static_cast<char>('a' + ((a * x + b) % 26));
    }

    static std::string format_output(const std::string &input)
    {
        std::string out;
        int count = 0;

        for (char c : input)
        {
            if (c == ' ')
                continue;

            if (count == 5)
            {
                out += ' ';
                count = 0;
            }

            out += c;
            ++count;
        }

        return out;
    }

    std::string encode(const std::string &plain_text, int a, int b)
    {
        if (!coprime(a, 26))
            throw std::invalid_argument("a and m must be coprime");

        std::string cleaned;
        cleaned.reserve(plain_text.size());

        for (char c : plain_text)
        {
            if (std::isalnum(static_cast<unsigned char>(c)))
                cleaned += static_cast<char>(std::tolower(c));
        }

        std::string encoded;
        encoded.reserve(cleaned.size());

        for (char c : cleaned)
            encoded += encode_char(c, a, b);

        return format_output(encoded);
    }

    std::string decode(const std::string &cipher_text, int a, int b)
    {
        if (!coprime(a, 26))
            throw std::invalid_argument("a and m must be coprime");

        int a_inv = mod_inverse(a, 26);
        if (a_inv == -1)
            throw std::invalid_argument("no modular inverse");

        std::string result;
        result.reserve(cipher_text.size());

        for (char c : cipher_text)
        {
            if (c == ' ')
                continue;

            if (std::isdigit(static_cast<unsigned char>(c)))
            {
                result += c;
                continue;
            }

            if (!std::isalpha(static_cast<unsigned char>(c)))
                continue;

            char lower = std::tolower(static_cast<unsigned char>(c));

            int y = lower - 'a';
            int x = (a_inv * ((y - b) % 26 + 26)) % 26;

            result += static_cast<char>('a' + x);
        }

        return result;
    }
} // namespace affine_cipher
