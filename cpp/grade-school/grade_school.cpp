#include "grade_school.h"
#include <algorithm>
#include <functional>

namespace grade_school
{
    void school::add(const std::string &name, unsigned int grade)
    {
        if (grades.find(grade) == grades.end())
        {
            grades.insert({grade, {name}});
        }
        else
        {
            std::vector<std::string> *v = &grades.at(grade);
            v->push_back(name);
            std::sort(v->begin(), v->end());
        }
    }

    std::map<int, std::vector<std::string>> school::roster() const
    {
        return grades;
    }

    std::vector<std::string> school::grade(int grade) const
    {
        if (grades.find(grade) == grades.end())
        {
            return std::vector<std::string>();
        }

        return grades.at(grade);
    }
} // namespace grade_school
