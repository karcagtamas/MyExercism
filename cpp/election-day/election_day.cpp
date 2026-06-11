#include <string>
#include <vector>

namespace election
{

    // The election result struct is already created for you:

    struct ElectionResult
    {
        // Name of the candidate
        std::string name{};
        // Number of votes the candidate has
        int votes{};
    };

    int vote_count(const ElectionResult &result)
    {
        return result.votes;
    }

    void increment_vote_count(ElectionResult &result, int votes)
    {
        result.votes += votes;
    }

    ElectionResult &determine_result(std::vector<ElectionResult> &results)
    {
        auto max_it = results.begin();

        for (auto it = results.begin(); it != results.end(); it++)
        {
            if (it->votes > max_it->votes)
            {
                max_it = it;
            }
        }

        max_it->name = "President " + max_it->name;

        return *max_it;
    }

} // namespace election
