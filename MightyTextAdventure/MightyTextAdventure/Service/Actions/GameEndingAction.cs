using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class GameEndingAction : Action
{
    public GameEndingAction(string description, string[] triggers, string afterDescription) : base(description, triggers, afterDescription)
    {
    }

    public override string Perform(Player player, Area[] areas)
    {
        return AfterDescription;
    }
}