using MightyTextAdventure.Data.Items;
using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class GiveItemAction : Action
{
    protected readonly Item Item;

    protected readonly Action ActionToUnlock;

    protected readonly string AfterDescription1;
    public GiveItemAction(string description, string[] triggers, string afterDescription, string afterDescription1, Item item, Action actionToUnlock) : base(description, triggers, afterDescription)
    {
        Item = item;
        ActionToUnlock = actionToUnlock;
        AfterDescription1 = afterDescription1;
    }

    public override string Perform(Player player, Area[] areas)
    {
        if (player.Inventory.RemoveItem(Item))
        {
            player.CurrentArea.Actions.Add(ActionToUnlock);
            player.CurrentArea.Actions.Remove(this);
            return AfterDescription;
        }

        return AfterDescription1;
    }
}