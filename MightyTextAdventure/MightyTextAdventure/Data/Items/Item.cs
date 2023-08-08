namespace MightyTextAdventure.Data.Items;

public class Item
{
  private readonly string _description;

  private readonly string _name;

  public Item(string name, string description)
  {
    _description = description;
    _name = name;
  }

  public virtual string GetDescription()
  {
    return _description;
  }

  public string GetName()
  {
    return _name;
  }

  public override string ToString()
  {
    return _description;
  }
}