namespace MightyTextAdventure.Data.Items;

public class Lamp : Item
{
    private int Charge;

    public Lamp(string name, string description, int charge) : base(description, name)
    {
        Charge = charge;
    }

    public void Drain()
    {
        Charge--;
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}. You have {Charge} charges remaining.";
    }
}