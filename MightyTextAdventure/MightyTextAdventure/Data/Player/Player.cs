using MightyTextAdventure.Data.Items;
using MightyTextAdventure.Data.Places;

namespace MightyTextAdventure.Data.Player;

public class Player
{
  private Area _currentArea;

  private readonly string _name;

  private Inventory _inventory;

  public string Name => _name;

  public Area CurrentArea
  {
    get => _currentArea;
    set
    {
      _currentArea = value;
    }
  }

  public Player(string name, Area startingArea)
  {
    _currentArea = startingArea;
    _name = name;

    _inventory = new Inventory(new Lamp("Lamp", "Just a regular lamp", 10));
  }


}