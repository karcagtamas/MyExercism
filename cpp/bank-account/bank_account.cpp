#include "bank_account.h"
#include <stdexcept>

namespace Bankaccount
{

    void Bankaccount::open()
    {
        std::lock_guard<std::mutex> lock(mutex);

        if (opened)
        {
            throw std::runtime_error("Account opened");
        }

        opened = true;
        b = 0;
    }

    void Bankaccount::close()
    {
        std::lock_guard<std::mutex> lock(mutex);

        if (!opened)
        {
            throw std::runtime_error("Account closed");
        }

        opened = false;
    }

    int Bankaccount::balance() const
    {
        std::lock_guard<std::mutex> lock(mutex);

        if (!opened)
        {
            throw std::runtime_error("Account closed");
        }

        return b;
    }

    void Bankaccount::deposit(int amount)
    {
        std::lock_guard<std::mutex> lock(mutex);

        if (!opened)
        {
            throw std::runtime_error("Account closed");
        }

        if (amount < 0)
        {
            throw std::runtime_error("Cannot deposit negative amount");
        }

        b += amount;
    }

    void Bankaccount::withdraw(int amount)
    {
        std::lock_guard<std::mutex> lock(mutex);

        if (!opened)
        {
            throw std::runtime_error("Account closed");
        }

        if (amount < 0)
        {
            throw std::runtime_error("Cannot withdraw negative amount");
        }

        if (amount > b)
        {
            throw std::runtime_error("Insufficient funds");
        }

        b -= amount;
    }
}
