#include "list_ops.h"
#include <algorithm>

namespace list_ops
{

    std::vector<int> append(std::vector<int> &left, const std::vector<int> &right)
    {
        for (auto i : right)
        {
            left.push_back(i);
        }

        return left;
    }

    size_t length(const std::vector<int> &input)
    {
        return input.size();
    }

} // namespace list_ops
