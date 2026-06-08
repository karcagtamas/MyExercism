namespace hellmath
{

    enum AccountStatus
    {
        troll,
        guest,
        user,
        mod
    };

    enum Action
    {
        read = 0,
        write = 1 << 0,
        remove = 1 << 1,
    };

    bool display_post(AccountStatus poster, AccountStatus viewer)
    {
        if (poster == AccountStatus::troll)
        {
            return viewer == AccountStatus::troll;
        }

        return true;
    }

    bool permission_check(Action action, AccountStatus account)
    {
        switch (account)
        {
        case AccountStatus::guest:
            return action == Action::read;
            break;

        case AccountStatus::user:
        case AccountStatus::troll:
            return action == Action::read || action == Action::write;

        case AccountStatus::mod:
            return true;
        }

        return false;
    }

    bool valid_player_combination(AccountStatus player1, AccountStatus player2)
    {
        if (player1 == AccountStatus::guest || player2 == AccountStatus::guest)
            return false;

        if (player1 == AccountStatus::troll || player2 == AccountStatus::troll)
            return player1 == AccountStatus::troll && player2 == AccountStatus::troll;

        return true;
    }

    bool has_priority(AccountStatus lhs, AccountStatus rhs)
    {
        auto priority = [](AccountStatus status)
        {
            return ((int)status) + 1;
        };

        return priority(lhs) > priority(rhs);
    }

} // namespace hellmath
