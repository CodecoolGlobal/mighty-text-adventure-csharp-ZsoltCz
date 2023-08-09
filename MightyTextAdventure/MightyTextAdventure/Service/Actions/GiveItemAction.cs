using MightyTextAdventure.Data.Items;
using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class GiveItemAction : Action
{
    private readonly Item _item;

    private readonly Action _actionToUnlock;

    private readonly string _afterDescription1;
    public GiveItemAction(string description, string[] triggers, string afterDescription, string afterDescription1, Item item, Action actionToUnlock) : base(description, triggers, afterDescription)
    {
        _item = item;
        _actionToUnlock = actionToUnlock;
        _afterDescription1 = afterDescription1;
    }

    public override string Perform(Player player, Area[] areas)
    {
        if (player.Inventory.RemoveItem(_item))
        {
            player.CurrentArea.Actions.Add(_actionToUnlock);
            player.CurrentArea.Actions.Remove(this);
        }

        return AfterDescription;
    }
}