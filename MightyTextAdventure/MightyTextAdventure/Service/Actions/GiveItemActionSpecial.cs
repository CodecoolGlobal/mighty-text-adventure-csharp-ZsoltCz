using MightyTextAdventure.Data.Items;
using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class GiveItemActionSpecial : GiveItemAction
{
    protected readonly int IndexOfAffectedArea;
    public GiveItemActionSpecial(string description, string[] triggers, string afterDescription, string afterDescription1, Item item, Action actionToUnlock, int indexOfAffectedArea) : base(description, triggers, afterDescription, afterDescription1, item, actionToUnlock)
    {
        IndexOfAffectedArea = indexOfAffectedArea;
    }

    public override string Perform(Player player, Area[] areas)
    {
        if (player.Inventory.RemoveItem(Item))
        {
            areas[IndexOfAffectedArea].Actions.Add(ActionToUnlock);
            player.CurrentArea.Actions.Remove(this);
            return AfterDescription;
        }

        return AfterDescription1;
    }
}