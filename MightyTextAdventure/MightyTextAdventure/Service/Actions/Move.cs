using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class Move : Action
{
  private readonly int _moveTo;

  private readonly Action? _preventingAction;
  public Move(string description, string[] triggers, string afterDescription, int moveTo) : base(description, triggers, afterDescription)
  {
    _moveTo = moveTo;
    _preventingAction = null;
  }
  
  public Move(string description, string[] triggers, string afterDescription, int moveTo, Action preventingAction) : base(description, triggers, afterDescription)
  {
    _moveTo = moveTo;
    _preventingAction = preventingAction;
  }

  public override void Perform(Player player, Area[] areas)
  {
    if (_preventingAction != null && player.CurrentArea.Actions.Contains(_preventingAction))
    {
      return;
    }
    Area nextArea = Array.Find(areas, area => area.Id == _moveTo);
    if (nextArea != null)
    {
      player.CurrentArea = nextArea;
    }
  }

}