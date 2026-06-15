#include "robot_name.h"

namespace robot_name
{

    robot::robot()
    {
        reset();
    }

    std::string robot::name() const
    {
        return robot_name;
    }

    void robot::reset()
    {
        if (!robot_name.empty())
        {
            registry.erase(robot_name);
        }

        robot_name = generate_unique_name();

        registry.insert(robot_name);
    }

    std::string robot::generate_unique_name()
    {
        static std::mt19937 rng(std::random_device{}());
        static const std::string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        std::uniform_int_distribution<int> letter_dist(0, 25);
        std::uniform_int_distribution<int> digit_dist(0, 9);

        std::string candidate;

        while (true)
        {
            candidate.clear();

            candidate += letters[letter_dist(rng)];
            candidate += letters[letter_dist(rng)];
            candidate += char('0' + digit_dist(rng));
            candidate += char('0' + digit_dist(rng));
            candidate += char('0' + digit_dist(rng));

            if (registry.find(candidate) == registry.end())
            {
                return candidate;
            }
        }
    }

} // namespace robot_name
