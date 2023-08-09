namespace MightyTextAdventure.Data.Items;

public class Lamp : Item
{
  private int _charge;

  public Lamp(string name, string description, int charge) : base(description, name)
  {
    _charge = charge;
  }

  public bool Drain()
  {
    _charge--;
    return _charge > 0;
  }

  public override string GetDescription()
  {
    return $"{base.GetDescription()}. You have {_charge} charges remaining.";
  }
}