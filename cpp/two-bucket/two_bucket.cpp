#include "two_bucket.h"
#include <algorithm>
#include <stdexcept>
#include <queue>
#include <set>

namespace two_bucket
{

    static int gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    measure_result measure(int bucket1_capacity, int bucket2_capacity, int target_volume, bucket_id start_bucket)
    {
        if (target_volume > std::max(bucket1_capacity, bucket2_capacity) ||
            target_volume % gcd(bucket1_capacity, bucket2_capacity) != 0)
        {
            throw std::domain_error("Impossible");
        }

        std::pair<int, int> start =
            (start_bucket == bucket_id::one)
                ? std::make_pair(bucket1_capacity, 0)
                : std::make_pair(0, bucket2_capacity);

        std::queue<std::pair<std::pair<int, int>, int>> q;
        std::set<std::pair<int, int>> visited;

        q.push({start, 1});
        visited.insert(start);

        while (!q.empty())
        {
            auto current = q.front();
            q.pop();

            int b1 = current.first.first;
            int b2 = current.first.second;
            int moves = current.second;

            if (b1 == target_volume || b2 == target_volume)
            {
                measure_result result;
                result.num_moves = moves;
                result.goal_bucket =
                    (b1 == target_volume) ? bucket_id::one : bucket_id::two;
                result.other_bucket_volume =
                    (b1 == target_volume) ? b2 : b1;
                return result;
            }

            std::vector<std::pair<int, int>> next_states = {
                {bucket1_capacity, b2},
                {b1, bucket2_capacity},
                {0, b2},
                {b1, 0}};

            int amount = std::min(b1, bucket2_capacity - b2);
            next_states.push_back({b1 - amount, b2 + amount});

            amount = std::min(b2, bucket1_capacity - b1);
            next_states.push_back({b1 + amount, b2 - amount});

            for (const auto &state : next_states)
            {
                if (start_bucket == bucket_id::one &&
                    state == std::make_pair(0, bucket2_capacity))
                {
                    continue;
                }

                if (start_bucket == bucket_id::two &&
                    state == std::make_pair(bucket1_capacity, 0))
                {
                    continue;
                }

                if (visited.insert(state).second)
                {
                    q.push({state, moves + 1});
                }
            }
        }

        throw std::domain_error("Impossible");
    }

} // namespace two_bucket
