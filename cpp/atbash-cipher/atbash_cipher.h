#pragma once
#include <string>

namespace atbash_cipher
{

    std::string encode(const std::string &plainValue);
    std::string decode(const std::string &cipher);

} // namespace atbash_cipher
