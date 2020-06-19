using System;

public static class Series {
    public static string[] Slices (string numbers, int sliceLength) {
        if (sliceLength <= 0 || numbers.Length < sliceLength) {
            throw new ArgumentException ();
        }
        int count = numbers.Length - sliceLength + 1;
        string[] array = new string[count];
        for (int i = 0; i < count; i++) {
            array[i] = numbers.Substring (i, sliceLength);
        }
        return array;
    }
}