using MightyTextAdventure.Data.Items;
using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class GiveItemAction : Action
{
    private readonly Item _item;

    private readonly Inventory _inventory;
    
    public GiveItemAction(string description, string[] triggers, string afterDescription, Item item) : base(description, triggers, afterDescription)
    {
        _item = item;
        _inventory = new Inventory();
    }

    public override void Perform(Player player, Area[] areas)
    {
        if (player.Inventory.RemoveItem(_item))
        {
            _inventory.AddItem(_item);
        }
    }
}