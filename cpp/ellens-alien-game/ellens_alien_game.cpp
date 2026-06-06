namespace targets
{

    class Alien
    {
    private:
        int health;

    public:
        int x_coordinate;
        int y_coordinate;

        Alien(int x, int y) : health(3), x_coordinate(x), y_coordinate(y) {}

        int get_health()
        {
            return health;
        }

        bool hit()
        {
            if (is_alive())
            {
                health -= 1;
            }

            return true;
        }

        bool is_alive()
        {
            return health > 0;
        }

        bool teleport(int new_x, int new_y)
        {
            x_coordinate = new_x;
            y_coordinate = new_y;
            return true;
        }

        bool collision_detection(const Alien &o)
        {
            return x_coordinate == o.x_coordinate && y_coordinate == o.y_coordinate;
        }
    };

} // namespace targets
