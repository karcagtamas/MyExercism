public class CircularBuffer<T>(int capacity)
{
    private readonly int capacity = capacity;

    private readonly T?[] array = new T?[capacity];
    private int head;
    private int tail;
    private int size;

    public T Read()
    {
        if (size == 0)
        {
            throw new InvalidOperationException();
        }

        var value = array[head];
        array[head] = default;
        head = (head + 1) % capacity;
        size--;
        return value!;
    }

    public void Write(T value)
    {
        if (size == capacity)
        {
            throw new InvalidOperationException();
        }

        array[tail] = value;
        tail = (tail + 1) % capacity;
        size++;
    }

    public void Overwrite(T value)
    {
        if (size == capacity)
        {
            array[tail] = value;
            head = (head + 1) % capacity;
            tail = (tail + 1) % capacity;
        }
        else
        {
            Write(value);
        }
    }

    public void Clear()
    {
        head = 0;
        tail = 0;
        size = 0;
    }
}