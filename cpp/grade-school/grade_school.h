#if !defined(GRADE_SCHOOL_H)
#define GRADE_SCHOOL_H
#include <vector>
#include <string>
#include <map>

namespace grade_school
{
    class school
    {
    private:
        std::map<int, std::vector<std::string>> grades;

    public:
        void add(const std::string &name, unsigned int grade);
        std::map<int, std::vector<std::string>> roster() const;
        std::vector<std::string> grade(int grade) const;
    };

} // namespace grade_school

#endif // GRADE_SCHOOL_H