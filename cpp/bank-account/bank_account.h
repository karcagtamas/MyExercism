#pragma once

#include <mutex>

namespace Bankaccount
{

    class Bankaccount
    {
    private:
        bool opened = false;
        int b = 0;
        mutable std::mutex mutex;

    public:
        void open();
        void close();

        int balance() const;
        void deposit(int amount);
        void withdraw(int amount);
    }; // class Bankaccount

} // namespace Bankaccount
