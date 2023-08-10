using MightyTextAdventure.Data.Items;
using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.Service.Constructor_classes;
using MightyTextAdventure.UI;
using MA = MightyTextAdventure.Service.Actions;

namespace MightyTextAdventure;

public class Game
{
  private Area[] _areas;

  private readonly Input _input;
  private readonly Display _display;
  private Player? _player;
  private readonly AreaConstructor _areaConstructor;

  public Game()
  {
    _areaConstructor = new AreaConstructor();
    _areas = Array.Empty<Area>();
    _input = new Input();
    _display = new Display();

  }

  public void Init()
  {
    LoadArea();
  }

  public void Run()
  {

    CreatePlayer();
    bool isRunning = true;
    while (isRunning)
    {
      Area playerCurrentArea = _player.CurrentArea;
      string areaDescription = playerCurrentArea.Description;
      _display.PrintMessage("\n" + areaDescription);

      for (int i = 0; i < playerCurrentArea.Actions.Count; i++)
      {
        _display.PrintMessage($"- {playerCurrentArea.Actions[i].Description}");
      }

      var playerInput = _input.GetInputFromUser();
      var chosenAction = playerCurrentArea.Actions.Find(a => a.Triggers.Contains(playerInput.ToLower()));
      if (chosenAction != null)
      {
        isRunning = Step(playerCurrentArea.Connections, chosenAction);
      }
      else
      {
        isRunning = Step(playerCurrentArea.Connections, new MA.Inspect("impossible action", Array.Empty<string>(), "Can't do that"));
      }
    }
  }

  private void LoadArea()
  {
    _areas = _areaConstructor.Areas;
  }

  private void CreatePlayer()
  {
    _display.PrintMessage("Please choose a name for your character.");
    string nameOfCharacter = _input.GetInputFromUser();
    var lamp = new Lamp("lamp", "a lamp", 30);
    Player player = new(nameOfCharacter, _areas[0], lamp);
    _player = player;
  }


  private bool Step(int[]? conn, MA.Action action)
  {
    if (action is MA.GameEndingAction)
    {
      _display.PrintMessage(action.Perform(_player, _areas));
      return false;
    }
    if (!_player.Lamp.Drain())
    {
      _display.PrintMessage("Your flashlight battery ran out!");
      return false;
    }
    _display.PrintMessage(_player.Lamp.GetDescription());
    _display.PrintMessage(action.Perform(_player, _areas));
    return true;
  }
}
