#include "kindergarten_garden.h"
#include <stdexcept>
#include <unordered_map>
#include <sstream>

namespace kindergarten_garden
{
    Plants get_plant(unsigned char ch)
    {
        switch (ch)
        {
        case 'G':
            return Plants::grass;
            break;
        case 'C':
            return Plants::clover;
            break;
        case 'R':
            return Plants::radishes;
            break;
        case 'V':
            return Plants::violets;
            break;

        default:
            throw std::invalid_argument("Invalid character");
            break;
        }
    }

    std::array<Plants, 4> plants(const std::string &plants, const std::string &student)
    {
        static const std::unordered_map<std::string, int> students{
            {"Alice", 0},
            {"Bob", 1},
            {"Charlie", 2},
            {"David", 3},
            {"Eve", 4},
            {"Fred", 5},
            {"Ginny", 6},
            {"Harriet", 7},
            {"Ileana", 8},
            {"Joseph", 9},
            {"Kincaid", 10},
            {"Larry", 11}};

        int start = students.at(student) * 2;

        std::string row1_;
        std::string row2_;

        std::stringstream ss(plants);
        std::getline(ss, row1_);
        std::getline(ss, row2_);

        return {
            get_plant(row1_[start]),
            get_plant(row1_[start + 1]),
            get_plant(row2_[start]),
            get_plant(row2_[start + 1])};
    }

} // namespace kindergarten_garden
