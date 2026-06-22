#pragma once
#include <vector>
#include <stdexcept>

namespace circular_buffer
{

    template <typename T>
    class circular_buffer
    {
    private:
        int capacity;
        std::vector<T> array;
        int size;
        int head;
        int tail;

    public:
        circular_buffer(int capacity);

        T read();
        void write(T value);
        void overwrite(T value);
        void clear();
    };

    template <typename T>
    circular_buffer<T>::circular_buffer(int capacity) : capacity(capacity), array(capacity), size(0), head(0), tail(0)
    {
    }

    template <typename T>
    T circular_buffer<T>::read()
    {
        if (size == 0)
        {
            throw std::domain_error("Buffer is empty");
        }

        T value = array[head];
        head = (head + 1) % capacity;
        --size;

        return value;
    }

    template <typename T>
    void circular_buffer<T>::write(T value)
    {
        if (size == capacity)
        {
            throw std::domain_error("Buffer is full");
        }

        array[tail] = value;
        tail = (tail + 1) % capacity;
        ++size;
    }

    template <typename T>
    void circular_buffer<T>::overwrite(T value)
    {
        if (size == capacity)
        {
            array[tail] = value;
            tail = (tail + 1) % capacity;
            head = tail;
            return;
        }

        write(value);
    }

    template <typename T>
    void circular_buffer<T>::clear()
    {
        size = 0;
        head = 0;
        tail = 0;
    }

} // namespace circular_buffer
