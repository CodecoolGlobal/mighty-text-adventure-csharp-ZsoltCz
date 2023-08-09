using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class Inspect : Action
{
    public Inspect(string description, string[] triggers, string afterDescription) : base(description, triggers, afterDescription)
    {
    }

    public override string Perform(Player player, Area[] areas)
    {
        return AfterDescription;
    }
}