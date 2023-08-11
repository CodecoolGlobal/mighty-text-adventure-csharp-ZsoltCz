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

  public string GetCharge()
  {
    Console.ForegroundColor = ConsoleColor.Green;
    return $"Your flashlight has {_charge} charges remaining.";
  }

  public override string ToString()
  {
    return $"{base.ToString()} It has {_charge} charges left";
  }
}