#pragma once

#include <memory>
#include <vector>
#include <stack>

namespace binary_search_tree
{

    template <typename T>
    class binary_tree
    {
    public:
        explicit binary_tree(T value);

        void insert(T value);

        T data() const;

        std::unique_ptr<binary_tree<T>> &left();
        std::unique_ptr<binary_tree<T>> &right();

        class iterator
        {
        public:
            using value_type = T;

            iterator(binary_tree<T> *root);

            T &operator*();
            iterator &operator++();

            bool operator!=(const iterator &other) const;

        private:
            std::stack<binary_tree<T> *> nodes;

            void push_left(binary_tree<T> *node);
        };

        iterator begin();
        iterator end();

    private:
        T value_;
        std::unique_ptr<binary_tree<T>> left_;
        std::unique_ptr<binary_tree<T>> right_;
    };

    template <typename T>
    binary_tree<T>::binary_tree(T value)
        : value_(value)
    {
    }

    template <typename T>
    void binary_tree<T>::insert(T value)
    {
        if (value <= value_)
        {
            if (left_)
                left_->insert(value);
            else
                left_ = std::make_unique<binary_tree<T>>(value);
        }
        else
        {
            if (right_)
                right_->insert(value);
            else
                right_ = std::make_unique<binary_tree<T>>(value);
        }
    }

    template <typename T>
    T binary_tree<T>::data() const
    {
        return value_;
    }

    template <typename T>
    std::unique_ptr<binary_tree<T>> &binary_tree<T>::left()
    {
        return left_;
    }

    template <typename T>
    std::unique_ptr<binary_tree<T>> &binary_tree<T>::right()
    {
        return right_;
    }

    template <typename T>
    binary_tree<T>::iterator::iterator(binary_tree<T> *root)
    {
        push_left(root);
    }

    template <typename T>
    void binary_tree<T>::iterator::push_left(binary_tree<T> *node)
    {
        while (node)
        {
            nodes.push(node);

            if (node->left_)
                node = node->left_.get();
            else
                break;
        }
    }

    template <typename T>
    T &binary_tree<T>::iterator::operator*()
    {
        return nodes.top()->value_;
    }

    template <typename T>
    typename binary_tree<T>::iterator &
    binary_tree<T>::iterator::operator++()
    {
        auto current = nodes.top();
        nodes.pop();

        if (current->right_)
            push_left(current->right_.get());

        return *this;
    }

    template <typename T>
    bool binary_tree<T>::iterator::operator!=(const iterator &other) const
    {
        return !nodes.empty() != !other.nodes.empty();
    }

    template <typename T>
    typename binary_tree<T>::iterator binary_tree<T>::begin()
    {
        return iterator(this);
    }

    template <typename T>
    typename binary_tree<T>::iterator binary_tree<T>::end()
    {
        return iterator(nullptr);
    }

} // namespace binary_search_tree
