#include "reverse_string.h"
#include <bits/stdc++.h>

namespace reverse_string
{
    std::string reverse_string(std::string text)
    {
        reverse(text.begin(), text.end());
        return text;
    }
} // namespace reverse_string
