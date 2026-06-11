#include "matching_brackets.h"
#include <stack>
#include <unordered_map>

namespace matching_brackets
{

    bool check(const std::string &text)
    {
        std::stack<unsigned char> stack;

        std::unordered_map<unsigned char, unsigned char> pairs = {
            {')', '('},
            {'}', '{'},
            {']', '['},
        };

        for (unsigned char ch : text)
        {
            bool is_opening = false;

            for (const auto &[close, open] : pairs)
            {
                if (open == ch)
                {
                    is_opening = true;
                    break;
                }
            }

            if (is_opening)
            {
                stack.push(ch);
            }
            else if (pairs.find(ch) != pairs.end())
            {
                if (stack.empty() || stack.top() != pairs.at(ch))
                {
                    return false;
                }

                stack.pop();
            }
        }

        return stack.size() == 0;
    }

} // namespace matching_brackets
