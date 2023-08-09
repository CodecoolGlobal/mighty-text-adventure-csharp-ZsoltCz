using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class Move : Action
{
  private readonly int _moveTo;
  public Move(string description, string[] triggers, string afterDescription, int moveTo) : base(description, triggers, afterDescription)
  {
    _moveTo = moveTo;
  }

  public override string Perform(Player player, Area[] areas)
  {
    
    Area nextArea = Array.Find(areas, area => area.Id == _moveTo);
    if (nextArea != null)
    {
      player.CurrentArea = nextArea;
    }

    return AfterDescription;
  }

}