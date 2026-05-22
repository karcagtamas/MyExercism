public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator(Direction direction, int x, int y)
{
    public Direction Direction { get; private set; } = direction;

    public int X { get; private set; } = x;

    public int Y { get; private set; } = y;

    public void Move(string instructions)
    {
        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case 'A':
                    switch (Direction)
                    {
                        case Direction.North: Y++; break;
                        case Direction.East: X++; break;
                        case Direction.South: Y--; break;
                        case Direction.West: X--; break;
                    }
                    break;
                case 'L':
                    Direction = (Direction)(((int)Direction - 1 + 4) % 4);
                    break;
                case 'R':
                    Direction = (Direction)(((int)Direction + 1) % 4);
                    break;
            }
        }
    }
}