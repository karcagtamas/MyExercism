#pragma once
#include <string>

namespace date_independent
{

    class clock
    {

    public:
        static clock at(int hour, int minute);

        clock plus(int minutes) const;
        clock substract(int minutes) const;

        std::string str() const;

        bool operator==(const clock &other) const;
        bool operator!=(const clock &other) const;

        operator std::string() const;

    private:
        int minutes_since_midnight;

        explicit clock(int minutes);

        static int normalize(int minutes);
    };

} // namespace date_independent
