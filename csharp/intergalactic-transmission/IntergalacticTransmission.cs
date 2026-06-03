public static class IntergalacticTransmission
{
    public static byte[] GetTransmitSequence(byte[] message)
    {
        var bits = new List<int>();

        foreach (var b in message)
        {
            for (int i = 7; i >= 0; i--)
            {
                bits.Add((b >> i) & 1);
            }
        }

        var result = new List<byte>();

        for (int i = 0; i < bits.Count; i += 7)
        {
            int value = 0;
            int ones = 0;

            for (int j = 0; j < 7; j++)
            {
                int bit = (i + j < bits.Count) ? bits[i + j] : 0;

                value = (value << 1) | bit;
                if (bit == 1) ones++;
            }

            int parity = ones % 2 == 0 ? 0 : 1;
            value = (value << 1) | parity;

            result.Add((byte)value);
        }

        return [.. result];
    }

    public static byte[] DecodeSequence(byte[] receivedSeq)
    {
        var bits = new List<int>();

        foreach (var b in receivedSeq)
        {
            int ones = 0;

            for (int i = 7; i >= 0; i--)
            {
                int bit = (b >> i) & 1;
                if (bit == 1) ones++;
                bits.Add(bit);
            }

            if (ones % 2 != 0) throw new ArgumentException("Corrupted transmission detected");
        }

        var dataBits = new List<int>();

        for (int i = 0; i < bits.Count; i++)
        {
            if ((i + 1) % 8 != 0) dataBits.Add(bits[i]);
        }

        var result = new List<byte>();

        for (int i = 0; i + 7 < dataBits.Count; i += 8)
        {
            int value = 0;

            for (int j = 0; j < 8; j++)
            {
                value = (value << 1) | dataBits[i + j];
            }

            result.Add((byte)value);
        }

        return [.. result];
    }
}
