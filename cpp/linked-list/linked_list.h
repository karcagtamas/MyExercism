#pragma once

#include <stdexcept>

namespace linked_list
{

    template <typename T>
    class List
    {
    private:
        class Node
        {
        public:
            T value;
            Node *next = nullptr;
            Node *prev = nullptr;

            Node(const T &value) : value(value), next(nullptr), prev(nullptr) {}
        };

        Node *head = nullptr;
        Node *tail = nullptr;
        int length = 0;

    public:
        ~List();

        void push(T value);
        T pop();
        void unshift(T value);
        T shift();
        void erase(T value);
        int count() const;
    };

    template <typename T>
    List<T>::~List()
    {
        while (head != nullptr)
        {
            Node *next = head->next;
            delete head;
            head = next;
        }
    }

    template <typename T>
    void List<T>::push(T value)
    {
        Node *node = new Node{value};

        if (tail == nullptr)
        {
            head = tail = node;
        }
        else
        {
            tail->next = node;
            node->prev = tail;
            tail = node;
        }

        ++length;
    }

    template <typename T>
    T List<T>::pop()
    {
        if (tail == nullptr)
            throw std::runtime_error("List is empty");

        Node *node = tail;
        T value = node->value;

        tail = node->prev;

        if (tail == nullptr)
        {
            head = nullptr;
        }
        else
        {
            tail->next = nullptr;
        }

        delete node;
        --length;

        return value;
    }

    template <typename T>
    void List<T>::unshift(T value)
    {
        Node *node = new Node(value);

        if (head == nullptr)
        {
            head = tail = node;
        }
        else
        {
            node->next = head;
            head->prev = node;
            head = node;
        }

        ++length;
    }

    template <typename T>
    T List<T>::shift()
    {
        if (head == nullptr)
            throw std::runtime_error("List is empty");

        Node *node = head;
        T value = node->value;

        head = head->next;

        if (head == nullptr)
        {
            tail = nullptr;
        }
        else
        {
            head->prev = nullptr;
        }

        delete node;
        --length;

        return value;
    }

    template <typename T>
    void List<T>::erase(T value)
    {
        Node *current = head;

        while (current != nullptr)
        {
            if (current->value == value)
            {
                if (current->prev != nullptr)
                {
                    current->prev->next = current->next;
                }
                else
                {
                    head = current->next;
                }

                if (current->next != nullptr)
                {
                    current->next->prev = current->prev;
                }
                else
                {
                    tail = current->prev;
                }

                delete current;
                --length;
                return;
            }

            current = current->next;
        }
    }

    template <typename T>
    int List<T>::count() const
    {
        return length;
    }

} // namespace linked_list
