public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var buffer = new byte[9];

        if (reading >= 0)
        {
            if (reading <= ushort.MaxValue)
            {
                buffer[0] = 2;
                Array.Copy(
                    BitConverter.GetBytes((ushort)reading),
                    0,
                    buffer,
                    1,
                    2
                );
            }
            else if (reading <= int.MaxValue)
            {
                buffer[0] = 252;
                Array.Copy(
                    BitConverter.GetBytes((int)reading),
                    0,
                    buffer,
                    1,
                    4
                );
            }
            else if (reading <= uint.MaxValue)
            {
                buffer[0] = 4;
                Array.Copy(
                    BitConverter.GetBytes((uint)reading),
                    0,
                    buffer,
                    1,
                    4
                );
            }
            else
            {
                buffer[0] = 248;
                Array.Copy(
                    BitConverter.GetBytes(reading),
                    0,
                    buffer,
                    1,
                    8
                );
            }
        }
        else
        {
            if (reading >= short.MinValue)
            {
                buffer[0] = 254;
                Array.Copy(
                    BitConverter.GetBytes((short)reading),
                    0,
                    buffer,
                    1,
                    2
                );
            }
            else if (reading >= int.MinValue)
            {
                buffer[0] = 252;
                Array.Copy(
                    BitConverter.GetBytes((int)reading),
                    0,
                    buffer,
                    1,
                    4
                );
            }
            else
            {
                buffer[0] = 248;
                Array.Copy(
                    BitConverter.GetBytes(reading),
                    0,
                    buffer,
                    1,
                    8
                );
            }
        }

        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        return buffer[0] switch
        {
            2 => BitConverter.ToUInt16(buffer, 1),
            254 => BitConverter.ToInt16(buffer, 1),
            4 => BitConverter.ToUInt32(buffer, 1),
            252 => BitConverter.ToInt32(buffer, 1),
            248 => BitConverter.ToInt64(buffer, 1),
            _ => 0
        };
    }
}
