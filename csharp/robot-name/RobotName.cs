using System;
using System.Collections.Generic;

public class Robot
{
    private string name = "";
    private const string LETTERS = "QWERTZUIOPASDFGHJKLYXCVBNM";
    private static HashSet<string> NAMES = new HashSet<string>();
    public string Name => name;

    private static Random rnd = new Random();

    public Robot()
    {
        this.Reset();
    }

    public void Reset()
    {
        string newName = "";
        do
        {
            newName += LETTERS[rnd.Next(0, LETTERS.Length)];
            newName += LETTERS[rnd.Next(0, LETTERS.Length)];
            newName += rnd.Next(0, 10);
            newName += rnd.Next(0, 10);
            newName += rnd.Next(0, 10);
        } while (NAMES.Contains(newName));
        NAMES.Add(newName);
        this.name = newName;
    }
}