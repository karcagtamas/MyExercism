#pragma once

#include <string>

namespace rotational_cipher
{

    char rotate(const char c, int shift);
    std::string rotate(const std::string &text, int shift);

} // namespace rotational_cipher
