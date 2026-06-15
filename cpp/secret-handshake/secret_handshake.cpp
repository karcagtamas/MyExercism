#include "secret_handshake.h"
#include <array>
#include <cmath>
#include <algorithm>

namespace secret_handshake
{

    static const std::array<std::string, 4> signals{
        "wink",
        "double blink",
        "close your eyes",
        "jump"};

    std::vector<std::string> commands(int command_value)
    {
        std::vector<std::string> results;

        for (size_t i = 0; i < signals.size(); i++)
        {
            if ((command_value & ((int)pow(2, i))) != 0)
            {
                results.push_back(signals[i]);
            }
        }

        if ((command_value & 16) != 0)
        {
            std::reverse(results.begin(), results.end());
        }

        return results;
    }

} // namespace secret_handshake
