using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly Dictionary<int, List<string>> _grades = [];

    public bool Add(string student, int grade)
    {
        if (ContainsAnyGrade(student))
        {
            return false;
        }

        if (_grades.ContainsKey(grade))
        {
            _grades[grade].Add(student);
        }
        else
        {
            _grades.Add(grade, [student]);
        }

        return true;
    }

    public IEnumerable<string> Roster()
    {
        var list = new List<string>();
        foreach (var grade in _grades.OrderBy(x => x.Key))
        {
            list.AddRange(grade.Value.OrderBy(x => x));
        }

        return list;
    }

    public IEnumerable<string> Grade(int grade) => _grades.ContainsKey(grade) ? _grades[grade].OrderBy(x => x) : [];

    private bool ContainsAnyGrade(string student)
    {
        foreach (var grade in _grades)
        {
            if (grade.Value.Contains(student))
            {
                return true;
            }
        }

        return false;
    }
}