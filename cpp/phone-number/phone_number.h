#pragma once

#include <string>

namespace phone_number
{

    class phone_number
    {
    public:
        explicit phone_number(const std::string &input);

        std::string number() const;

    private:
        std::string num;
    };

} // namespace phone_number
