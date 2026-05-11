abstract class Character
{
    protected string characterType;

    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    private bool isSpellPrepared;

    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target) => isSpellPrepared ? 12 : 3;

    public override bool Vulnerable() => !isSpellPrepared;

    public void PrepareSpell() => isSpellPrepared = true;
}
