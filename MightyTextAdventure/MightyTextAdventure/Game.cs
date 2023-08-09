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
  private Player _player;
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
      _display.PrintMessage(areaDescription);

      for (int i = 0; i < playerCurrentArea.Actions.Count; i++)
      {

        _display.PrintMessage($"{i + 1} - {playerCurrentArea.Actions[i].Description}");
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
    // Item thing = new Item("thing", "A thing");
    // MA.TakeItemAction itemAction = new("Pick up thing", new string[] { "pickup", "take" }, "I picked up an item",
    //   thing);
    // string[] triggers = new string[] { "move", "m", "go" };
    // MA.Move action = new("move", triggers, "I moved to the next area", 1);
    // var actionArr = new List<MA.Action> { action, itemAction };
    //
    // MA.TakeItemAction preventingAction = new("Place thing on table", new string[] { "place" },
    //   "I placed the thing on the table", thing);
    //
    // MA.Move action2 = new("move", triggers, "I moved to the next area", 2, preventingAction);
    // var actionArr2 = new List<MA.Action> { action2, preventingAction };
    //
    // MA.Action gotoBeginning =
    //   new MA.Move("move back to beginning", new string[1] { "back" }, "I moved back to the start", 0);
    // List<MA.Action> actionList3 = new(){gotoBeginning};
    //
    // _areas[0] = new Area(0, "Start room", actionArr, new int[] { 1 });
    // _areas[1] = new Area(1, "Room 1", actionArr2, new int[] { 0, 2 });
    // _areas[2] = new Area(2, "End room", actionList3, new int[] { 0 });
    //_areas[3] = new Area("Room 3");
    //_areas[4] = new Area("Room 4");
    //_areas[5] = new Area("Room 5");
    //_areas[6] = new Area("Room 6");
  }

  private void CreatePlayer()
  {
    _display.PrintMessage("Please choose a name for your character.");
    string nameOfCharacter = _input.GetInputFromUser();
    var lamp = new Lamp("lamp", "a lamp", 20);
    Player player = new(nameOfCharacter, _areas[0], lamp);
    _player = player;
  }


  private bool Step(int[]? conn, MA.Action action)
  {
    Console.WriteLine($"number of actions in area 0: {_areas[0].Actions.Count}");
    if (action is MA.GameEndingAction)
    {
      _display.PrintMessage(action.Perform(_player, _areas));
      return false;
    }
    if (!_player.Lamp.Drain())
    {
      _display.PrintMessage("Your flashlight battery ran out!");
      return false;
      //Game over
    }
    _display.PrintMessage(_player.Lamp.GetDescription());
    _display.PrintMessage(action.Perform(_player, _areas));
    return true;
  }

  
}
