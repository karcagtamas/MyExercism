#if !defined(ALPHAMETICS_H)
#define ALPHAMETICS_H

#include <optional>
#include <string>
#include <vector>
#include <unordered_map>
#include <unordered_set>

namespace alphametics
{

    bool dfs(int idx, const std::vector<char> &letters, std::unordered_map<char, int>& assign, int used, const std::unordered_map<char, long long> &coeff, const std::unordered_set<char> &leading);

    std::optional<std::unordered_map<char, int>> solve(const std::string &puzzle);

} // namespace alphametics

#endif // ALPHAMETICS_H
