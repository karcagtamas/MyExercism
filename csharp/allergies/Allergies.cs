using System;
using System.Collections.Generic;

public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    private List<Allergen> allergens = new List<Allergen>();
    public Allergies(int mask)
    {
        int k = 0;
        while (mask != 0)
        {
            int num = this.findBiggest(mask);
            switch (num)
            {
                case 1:
                    this.allergens.Insert(0, Allergen.Eggs);
                    break;
                case 2:
                    this.allergens.Insert(0, Allergen.Peanuts);
                    break;
                case 4:
                    this.allergens.Insert(0, Allergen.Shellfish);
                    break;
                case 8:
                    this.allergens.Insert(0, Allergen.Strawberries);
                    break;
                case 16:
                    this.allergens.Insert(0, Allergen.Tomatoes);
                    break;
                case 32:
                    this.allergens.Insert(0, Allergen.Chocolate);
                    break;
                case 64:
                    this.allergens.Insert(0, Allergen.Pollen);
                    break;
                case 128:
                    this.allergens.Insert(0, Allergen.Cats);
                    break;

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

    public bool IsAllergicTo(Allergen allergen)
    {
        return this.allergens.Contains(allergen);
    }

    public Allergen[] List()
    {
        return this.allergens.ToArray();
    }
}