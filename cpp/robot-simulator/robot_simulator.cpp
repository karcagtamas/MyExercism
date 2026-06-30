#include "robot_simulator.h"

namespace robot_simulator
{

    Robot::Robot(std::pair<int, int> position, Bearing bearing) : position(position), bearing(bearing) {}

    std::pair<int, int> Robot::get_position() const
    {
        return position;
    }

    Bearing Robot::get_bearing() const
    {
        return bearing;
    }

    void Robot::turn_left()
    {
        bearing = (Bearing)(((int)bearing - 1 + 4) % 4);
    }

    void Robot::turn_right()
    {
        bearing = (Bearing)(((int)bearing + 1) % 4);
    }

    void Robot::advance()
    {
        int x = position.first;
        int y = position.second;
        switch (bearing)
        {
        case Bearing::NORTH:
            y++;
            break;
        case Bearing::EAST:
            x++;
            break;
        case Bearing::SOUTH:
            y--;
            break;
        case Bearing::WEST:
            x--;
            break;
        }

        position = {x, y};
    }

    void Robot::execute_sequence(const std::string &instructions)
    {
        for (auto instruction : instructions)
        {
            switch (instruction)
            {
            case 'A':
                advance();
                break;
            case 'L':
                turn_left();
                break;
            case 'R':
                turn_right();
                break;
            }
        }
    }
} // namespace robot_simulator
