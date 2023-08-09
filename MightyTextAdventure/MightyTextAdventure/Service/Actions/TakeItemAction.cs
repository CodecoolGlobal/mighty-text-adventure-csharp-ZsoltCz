using MightyTextAdventure.Data.Items;
using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class TakeItemAction:Action
{
  protected readonly Item Item;

  protected readonly Inventory Inventory;
  public TakeItemAction(string description, string[] triggers, string afterDescription, Item item):base(description, triggers, afterDescription)
  {
    Item = item;
    Inventory = new Inventory();
    Inventory.AddItem(item);
  }

  public override string Perform(Player player, Area[] areas)
  {
    if (Inventory.RemoveItem(Item))
    {
      player.Inventory.AddItem(Item);
      player.CurrentArea.Actions.Remove(this);
    }

    return AfterDescription;
  }

}
