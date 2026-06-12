#if !defined(ALPHAMETICS_H)
#define ALPHAMETICS_H

#include <optional>
#include <map>
#include <string>

namespace alphametics
{

    long long word_value(const std::string &word, const std::map<char, int> &m);

    std::optional<std::map<char, int>> solve(const std::string &puzzle);

} // namespace alphametics

#endif // ALPHAMETICS_H
