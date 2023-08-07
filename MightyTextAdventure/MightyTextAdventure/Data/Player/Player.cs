using MightyTextAdventure.Data.Items;
using MightyTextAdventure.Data.Places;

namespace MightyTextAdventure.Data.Player;

public class Player
{
    private Area _currentArea;
    
    private string _name;

    private Inventory _inventory;

    public Player(Area startingArea)
    {
        _currentArea = startingArea;
        _name = "";
        
        _inventory = new Inventory(new Lamp("Lamp", "Just a regular lamp", 10));
    }

    public void Rename(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }
}