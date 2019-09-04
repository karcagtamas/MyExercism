using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private List<int> scores;

    public HighScores(List<int> list)
    {
        this.scores = list;
    }

    public List<int> Scores()
    {
        return this.scores;
    }

    public int Latest()
    {
        return this.scores.Last();
    }

    public int PersonalBest()
    {
        return this.scores.Max();
    }

    public List<int> PersonalTopThree()
    {
        return this.scores.OrderByDescending(x => x).Take(3).ToList();
    }
}