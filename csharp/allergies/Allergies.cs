using System;
using System.Collections.Generic;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private List<Allergen> _allergens = new List<Allergen>();
    private readonly int _mask;
    public Allergies(int mask)
    {
        this._mask = mask;
        this.DetermineAllergens();
    }

    private void DetermineAllergens()
    {
        int mask = this._mask;
        this._allergens = new List<Allergen>();
        while (mask != 0)
        {
            int num = this.findBiggest(mask);
            if (num <= 128)
            {
                this._allergens.Insert(0, (Allergen)num);
            }
            mask -= num;
        }
    }

    private int findBiggest(int mask)
    {
        bool f = true;
        for (int i = 0; f; i++)
        {
            int x = (int)Math.Pow(2, i);
            if (x > mask)
            {
                return (int)Math.Pow(2, i - 1);
            }
        }
        return 0;
    }

    public bool IsAllergicTo(Allergen allergen) => this._allergens.Contains(allergen);

    public Allergen[] List() => this._allergens.ToArray();
}