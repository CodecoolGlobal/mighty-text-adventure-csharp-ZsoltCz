using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public abstract class Action
{
  public string Description;

  public string[] Triggers;

  public string AfterDescription;

  public Action(string description, string[] triggers, string afterDescription)
  {
    Description = description;
    Triggers = triggers;
    AfterDescription = afterDescription;
  }


  public abstract string Perform(Player player, Area[] areas);
}