using MightyTextAdventure.Data.Items;
using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class PlaceLadderAction : GiveItemActionSpecial
{
    private readonly Action _actionToUnlockInCurrentArea;
    public PlaceLadderAction(string description, string[] triggers, string afterDescription, string afterDescription1, Item item, Action actionToUnlock, int indexOfAffectedArea, Action actionToUnlockInCurrentArea) : base(description, triggers, afterDescription, afterDescription1, item, actionToUnlock, indexOfAffectedArea)
    {
        _actionToUnlockInCurrentArea = actionToUnlockInCurrentArea;
    }

    public override string Perform(Player player, Area[] areas)
    {
        if (player.Inventory.RemoveItem(Item))
        {
            areas[IndexOfAffectedArea].Actions.Add(ActionToUnlock);
            player.CurrentArea.Actions.Add(_actionToUnlockInCurrentArea);
            player.CurrentArea.Actions.Remove(this);
            return AfterDescription;
        }

        return AfterDescription1;
    }
}