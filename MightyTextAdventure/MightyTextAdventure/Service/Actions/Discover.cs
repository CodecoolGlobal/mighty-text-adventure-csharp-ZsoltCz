using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class Discover : Action
{
    private readonly Action _actionToUnlock;
    public Discover(string description, string[] triggers, string afterDescription, Action actionToUnlock) : base(description, triggers, afterDescription)
    {
        _actionToUnlock = actionToUnlock;
    }

    public override string Perform(Player player, Area[] areas)
    {
        player.CurrentArea.Actions.Add(_actionToUnlock);
        player.CurrentArea.Actions.Remove(this);
        return AfterDescription;
    }
}