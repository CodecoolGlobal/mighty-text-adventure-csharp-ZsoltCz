using MightyTextAdventure.Data.Items;
using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class TakeItemActionSpecial : TakeItemAction
{
    private readonly int _indexOfAffectedArea;
    private readonly Action _actionToUnlock;
    public TakeItemActionSpecial(string description, string[] triggers, string afterDescription, Item item, int indexOfAffectedArea, Action actionToUnlock) : base(description, triggers, afterDescription, item)
    {
        _indexOfAffectedArea = indexOfAffectedArea;
        _actionToUnlock = actionToUnlock;
    }

    public override string Perform(Player player, Area[] areas)
    {
        if (Inventory.RemoveItem(Item))
        {
            player.Inventory.AddItem(Item);
            player.CurrentArea.Actions.Remove(this);
            areas[_indexOfAffectedArea].Actions.Add(_actionToUnlock);
        }

        return AfterDescription;
    }
}