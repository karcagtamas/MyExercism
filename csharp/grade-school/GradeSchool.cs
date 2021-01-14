using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private Dictionary<int, List<string>> _grades = new Dictionary<int, List<string>>();

    public void Add(string student, int grade)
    {
        if (_grades.ContainsKey(grade))
        {
            _grades[grade].Add(student);
        }
        else
        {
            _grades.Add(grade, new List<string> {student});
        }
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

    public IEnumerable<string> Grade(int grade)
    {
        if (_grades.ContainsKey(grade))
        {
            return _grades[grade].OrderBy(x => x);
        }
        else
        {
            return new List<string>();
        }
    }
}