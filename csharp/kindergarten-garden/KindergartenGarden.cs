using System.Data;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden(string diagram)
{
    private readonly string[] rows = diagram.Split('\n');
    private readonly string[] students = [
        "Alice", "Bob", "Charlie", "David",
        "Eve", "Fred", "Ginny", "Harriet",
        "Ileana", "Joseph", "Kincaid", "Larry"
    ];

    public IEnumerable<Plant> Plants(string student)
    {
        var i = Array.IndexOf(students, student);

        if (i == -1)
        {
            throw new ArgumentException("Unknown student");
        }

        var start = i * 2;


        yield return GetPlant(rows[0][start]);
        yield return GetPlant(rows[0][start + 1]);
        yield return GetPlant(rows[1][start]);
        yield return GetPlant(rows[1][start + 1]);
    }

    private Plant GetPlant(char ch) => ch switch
    {
        'G' => Plant.Grass,
        'C' => Plant.Clover,
        'R' => Plant.Radishes,
        'V' => Plant.Violets,
        _ => throw new ArgumentException("Unexpected character: " + ch)
    };
}