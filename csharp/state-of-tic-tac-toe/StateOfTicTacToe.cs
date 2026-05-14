public enum State
{
    Win,
    Draw,
    Ongoing,
    Invalid
}

public class TicTacToe(string[] rows)
{
    private readonly string[] _rows = rows;

    public State State
    {
        get
        {
            var xCount = _rows.Sum(row => row.Count(c => c == 'X'));
            var oCount = _rows.Sum(row => row.Count(c => c == 'O'));

            if (oCount > xCount || xCount - oCount > 1)
            {
                return State.Invalid;
            }

            var xWins = HasWon('X');
            var oWins = HasWon('O');

            if (xWins && oWins)
            {
                return State.Invalid;
            }

            if (xWins && xCount != oCount + 1)
            {
                return State.Invalid;
            }

            if (oWins && xCount != oCount)
            {
                return State.Invalid;
            }

            if (xWins || oWins)
            {
                return State.Win;
            }

            var hasEmpty = _rows.Any(row => row.Contains(' '));

            return hasEmpty ? State.Ongoing : State.Draw;
        }
    }

    private bool HasWon(char player)
    {
        for (var i = 0; i < 3; i++)
        {
            if (_rows[i][0] == player &&
                _rows[i][1] == player &&
                _rows[i][2] == player)
            {
                return true;
            }

            if (_rows[0][i] == player &&
                _rows[1][i] == player &&
                _rows[2][i] == player)
            {
                return true;
            }
        }

        return
            (_rows[0][0] == player &&
             _rows[1][1] == player &&
             _rows[2][2] == player)
            ||
            (_rows[0][2] == player &&
             _rows[1][1] == player &&
             _rows[2][0] == player);
    }
}
