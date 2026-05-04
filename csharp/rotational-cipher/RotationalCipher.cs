using System;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey) => text.Aggregate("", (current, c) => current + Rotate(c, shiftKey));

    private static char Rotate(char character, int shiftKey)
    {
        if (character >= 'a' && character <= 'z')
        {
            return (char)(((character - 'a' + shiftKey) % 26) + 'a');
        }
        else if (character >= 'A' && character <= 'Z')
        {
            return (char)(((character - 'A' + shiftKey) % 26) + 'A');
        }

        return character;
    }
}