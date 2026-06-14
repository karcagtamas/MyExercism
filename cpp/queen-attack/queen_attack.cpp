#include "queen_attack.h"
#include <stdexcept>

namespace queen_attack
{

    chess_board::chess_board(std::pair<int, int> white, std::pair<int, int> black) : _white(white), _black(black)
    {
        validate(_white);
        validate(_black);

        if (_white == _black)
        {
            throw std::domain_error("Queens cannot occupy same position");
        }
    }

    std::pair<int, int> chess_board::white() const
    {
        return _white;
    }

    std::pair<int, int> chess_board::black() const
    {
        return _black;
    }

    bool chess_board::can_attack() const
    {
        if (_white.first == _black.first)
        {
            return true;
        }

        if (_white.second == _black.second)
        {
            return true;
        }

        return std::abs(_white.first - _black.first) ==
               std::abs(_white.second - _black.second);
    }

    void chess_board::validate(const std::pair<int, int> &pos)
    {
        if (pos.first < 0 || pos.first > 7 ||
            pos.second < 0 || pos.second > 7)
        {
            throw std::domain_error("Position outside board");
        }
    }
} // namespace queen_attack
