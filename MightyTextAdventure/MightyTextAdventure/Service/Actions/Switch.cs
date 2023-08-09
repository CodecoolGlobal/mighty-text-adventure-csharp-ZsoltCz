using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class Switch : Action
{
    private readonly Action _actionToUnlock1;
    private readonly Action _actionToUnlock2;
    private readonly string _afterDescription1;
    private readonly string _afterDescription2;
    public Switch(string description, string[] triggers, string afterDescription, string afterDescription1, string afterDescription2, Action actionToUnlock1, Action actionToUnlock2) : base(description, triggers, afterDescription)
    {
        _actionToUnlock1 = actionToUnlock1;
        _actionToUnlock2 = actionToUnlock2;
        _afterDescription1 = afterDescription1;
        _afterDescription2 = afterDescription2;
    }

    public override string Perform(Player player, Area[] areas)
    {
        var availableActions = player.CurrentArea.Actions;
        if (availableActions.Contains(_actionToUnlock1))
        {
            availableActions.Remove(_actionToUnlock1);
            availableActions.Add(_actionToUnlock2);
            return _afterDescription2;
        }
        else if (availableActions.Contains(_actionToUnlock2))
        {
            availableActions.Remove(_actionToUnlock2);
            availableActions.Add(_actionToUnlock1);
            return _afterDescription1;
        }
        else
        {
            availableActions.Add(_actionToUnlock1);
            return AfterDescription;
        }
    }
}