#pragma once
#include <string>
#include <unordered_set>
#include <random>

namespace robot_name
{

    class robot
    {
    public:
        robot();
        std::string name() const;
        void reset();

    private:
        std::string robot_name;

        inline static std::unordered_set<std::string> registry{};

        static std::string generate_unique_name();
    };

} // namespace robot_name
