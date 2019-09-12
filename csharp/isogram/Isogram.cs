using System;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        string modified = word.ToLower().Replace(" ", "").Replace("-", "");
        for (int i = 0; i < modified.Length - 1; i++)
        {
            if (Count(modified, modified[i], i) > 1){
                return false;
            }
        }
        return true;
    }

    public static int Count(string word, char toFind, int index)
    {
        int count = 1;
        for (int i = index + 1; i < word.Length; i++)
        {
            if (word[i] == toFind){
                count++;
            }
        }
        return count;
    }
}
