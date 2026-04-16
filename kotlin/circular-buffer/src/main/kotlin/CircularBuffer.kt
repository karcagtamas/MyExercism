class EmptyBufferException : Throwable()

class BufferFullException : Throwable()

class CircularBuffer<T>(private val capacity: Int) {

    private val array = arrayOfNulls<Any>(capacity)
    private var head = 0
    private var tail = 0
    private var size = 0

    fun read(): T {
        if (size == 0) {
            throw EmptyBufferException()
        }

        val value = array[head] as T
        array[head] = null
        head = (head + 1) % capacity
        size--
        return value
    }

    fun write(value: T) {
        if (size == capacity) {
            throw BufferFullException()
        }

        array[tail] = value
        tail = (tail + 1) % capacity
        size++
    }

    fun overwrite(value: T) {
        if (size == capacity) {
            array[tail] = value
            head = (head + 1) % capacity
            tail = (tail + 1) % capacity
        } else {
            write(value)
        }
    }

    fun clear() {
        head = 0
        tail = 0
        size = 0
    }
}