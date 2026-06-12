#include "simple_linked_list.h"

#include <stdexcept>

namespace simple_linked_list
{

    std::size_t List::size() const
    {
        return current_size;
    }

    void List::push(int entry)
    {
        Element *node = new Element(entry);
        node->next = head;
        head = node;

        ++current_size;
    }

    int List::pop()
    {
        Element *node = head;
        int value = node->data;

        head = head->next;

        delete node;
        --current_size;

        return value;
    }

    void List::reverse()
    {
        Element *prev = nullptr;
        Element *current = head;

        while (current != nullptr)
        {
            Element *next = current->next;

            current->next = prev;
            prev = current;
            current = next;
        }

        head = prev;
    }

    List::~List()
    {
        while (head != nullptr)
        {
            Element *next = head->next;
            delete head;
            head = next;
        }
    }

} // namespace simple_linked_list
