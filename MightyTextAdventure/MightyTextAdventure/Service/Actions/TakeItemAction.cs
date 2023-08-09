using MightyTextAdventure.Data.Items;
using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class TakeItemAction:Action
{
  private readonly Item _item;

  private readonly Inventory _inventory;
  public TakeItemAction(string description, string[] triggers, string afterDescription, Item item):base(description, triggers, afterDescription)
  {
    _item = item;
    _inventory = new Inventory();
    _inventory.AddItem(item);
  }

  public override string Perform(Player player, Area[] areas)
  {
    if (_inventory.RemoveItem(_item))
    {
      player.Inventory.AddItem(_item);
      player.CurrentArea.Actions.Remove(this);
    }

    return AfterDescription;
  }

}
