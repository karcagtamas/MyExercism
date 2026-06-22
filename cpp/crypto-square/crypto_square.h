#pragma once
#include <string>
#include <cctype>

namespace crypto_square
{

    class cipher
    {
    public:
        cipher(const std::string &text);

        std::string normalized_cipher_text();

    private:
        std::string text;

        std::pair<int, int> rectangle(const std::string &normalized);
    };

} // namespace crypto_square
