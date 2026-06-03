#include <string>
#include <algorithm>

namespace log_line
{
    static std::string trim(const std::string &str)
    {
        auto start = std::find_if_not(str.begin(), str.end(), [](unsigned char ch)
                                      { return std::isspace(ch); });
        auto end = std::find_if_not(str.rbegin(), str.rend(), [](unsigned char ch)
                                    { return std::isspace(ch); })
                       .base();

        return (start < end) ? std::string(start, end) : "";
    }

    std::string message(std::string line)
    {
        return trim(line.substr(line.find_first_of(':') + 1));
    }

    std::string log_level(std::string line)
    {
        auto start = line.find('[') + 1;
        auto end = line.find(']');

        std::string level = line.substr(start, end - start);
        return level;
    }

    std::string reformat(std::string line)
    {
        return message(line) + " (" + log_level(line) + ")";
    }
} // namespace log_line
