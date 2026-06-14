#pragma once
#include <utility>

namespace queen_attack
{

    class chess_board
    {
    private:
        std::pair<int, int> _white;
        std::pair<int, int> _black;

    public:
        chess_board(std::pair<int, int> white, std::pair<int, int> black);
        std::pair<int, int> white() const;
        std::pair<int, int> black() const;
        bool can_attack() const;
        static void validate(const std::pair<int, int> &pos);
    };

} // namespace queen_attack
