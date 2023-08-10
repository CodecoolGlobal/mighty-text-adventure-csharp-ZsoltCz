using MightyTextAdventure.Data.Items;
using MightyTextAdventure.Data.Places;

namespace MightyTextAdventure.Data.Player;

public class Player
{
  private Area _currentArea;

  private readonly string _name;

  private Inventory _inventory;

  public Lamp Lamp { get; }

  public Inventory Inventory => _inventory;

  public string Name => _name;

  public Area CurrentArea
  {
    get => _currentArea;
    set
    {
      _currentArea = value;
    }
  }

  public Player(string name, Area startingArea, Lamp lamp)
  {
    _currentArea = startingArea;
    _name = name;
    Lamp = lamp;
    _inventory = new Inventory();
  }


}