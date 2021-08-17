using System;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey) => text.Aggregate("", (current, c) => current + Rotate(c, shiftKey));

    private static char Rotate(char character, int shiftKey)
    {
        if ((character < 'A' || character > 'Z') && (character < 'a' || character > 'z'))
        {
            return character;
        }
        
        
        int baseChar = character >= 'a' && character <= 'z' ? 'a' : 'A';
        int num = (character - baseChar + shiftKey) % ('z' - 'a' + 1);
        return (char)(num + baseChar);
    }
}