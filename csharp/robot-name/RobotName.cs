using System;
using System.Collections.Generic;

public class Robot
{
    private string name = "";
    private const string LETTERS = "QWERTZUIOPASDFGHJKLYXCVBNM";
    private static readonly HashSet<string> NAMES = [];
    public string Name => name;

    private static readonly Random rnd = new();

    public Robot() => Reset();

    public void Reset()
    {
        string newName;
        do
        {
            newName = "";
            newName += LETTERS[rnd.Next(0, LETTERS.Length)];
            newName += LETTERS[rnd.Next(0, LETTERS.Length)];
            newName += rnd.Next(0, 10);
            newName += rnd.Next(0, 10);
            newName += rnd.Next(0, 10);
        } while (NAMES.Contains(newName));
        NAMES.Add(newName);
        name = newName;
    }
}