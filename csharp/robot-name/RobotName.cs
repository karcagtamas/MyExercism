using System;
using System.Collections.Generic;

public class Robot
{
    private string name = "";
    private static string LETTERS = "QWERTZUIOPASDFGHJKLYXCVBNM";
    private static List<string> NAMES = new List<string>();
    public string Name
    {
        get
        {
            return name;
        }
    }

    public Robot()
    {
        this.Reset();
    }

    public void Reset()
    {
        string newName = "";
        Random r = new Random();
        do
        {
            newName += LETTERS[r.Next(0, LETTERS.Length)];
            newName += LETTERS[r.Next(0, LETTERS.Length)];
            newName += r.Next(0, 10);
            newName += r.Next(0, 10);
            newName += r.Next(0, 10);
        } while (NAMES.Contains(newName));
        NAMES.Add(newName);
        this.name = newName;
    }
}