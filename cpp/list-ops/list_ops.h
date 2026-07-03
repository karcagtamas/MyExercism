#pragma once

#include <vector>

namespace list_ops
{

    std::vector<int> append(std::vector<int> &left, const std::vector<int> &right);

    template <typename T>
    std::vector<T> concat(const std::vector<std::vector<T>> &input)
    {
        std::vector<T> result{};

        for (auto i : input)
        {
            for (auto j : i)
            {
                result.push_back(j);
            }
        }

        return result;
    }

    size_t length(const std::vector<int> &input);

    template <typename T, typename Pred>
    std::vector<T> filter(const std::vector<T> &input, Pred pred)
    {
        std::vector<T> result{};

        for (auto i : input)
        {
            if (pred(i))
            {
                result.push_back(i);
            }
        }

        return result;
    }

    template <typename T, typename Transform>
    std::vector<T> map(const std::vector<T> &input, Transform transform)
    {
        std::vector<T> result{};

        for (auto i : input)
        {
            result.push_back(transform(i));
        }

        return result;
    }

    template <typename T>
    std::vector<T> reverse(const std::vector<T> &input)
    {
        return std::vector<T>(input.rbegin(), input.rend());
    }

    template <typename T, typename U, typename Op>
    U foldl(const std::vector<T> &input, U init, Op op)
    {
        for (int x : input)
        {
            init = op(init, x);
        }
        return init;
    }

    template <typename T, typename U, typename Op>
    U foldr(const std::vector<T> &input, U init, Op op)
    {
        for (auto it = input.rbegin(); it != input.rend(); ++it)
        {
            init = op(init, *it);
        }
        return init;
    }

} // namespace list_ops
