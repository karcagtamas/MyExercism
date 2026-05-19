public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        var result = new List<uint>();

        foreach (var number in numbers)
        {
            var stack = new Stack<uint>();
            var n = number;

            stack.Push(n & 0x7F);
            n >>= 7;

            while (n > 0)
            {
                stack.Push((n & 0x7F) | 0x80);
                n >>= 7;
            }

            foreach (var b in stack)
            {
                result.Add(b);
            }
        }

        return [.. result];
    }

    public static uint[] Decode(uint[] bytes)
    {
        var result = new List<uint>();
        uint value = 0;
        bool hasPartial = false;

        foreach (var b in bytes)
        {
            hasPartial = true;
            value = (value << 7) | (b & 0x7F);

            if ((b & 0x80) == 0)
            {
                result.Add(value);
                value = 0;
                hasPartial = false;
            }
        }

        if (hasPartial)
        {
            throw new InvalidOperationException();
        }

        return [.. result];
    }
}