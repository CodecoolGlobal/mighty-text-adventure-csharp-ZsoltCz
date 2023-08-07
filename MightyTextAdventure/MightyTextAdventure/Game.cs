using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.UI;
using MA = MightyTextAdventure.Service.Actions;

namespace MightyTextAdventure;

public class Game
{
  private readonly Area[] _areas;

  private readonly Input _input;
  private readonly Display _display;
  private Player _player;

  public Game()
  {
    //_areas = new Area[7];
    _areas = new Area[3];

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

      for (int i = 0; i < playerCurrentArea.Actions?.Length; i++)
      {

        _display.PrintMessage($"{i + 1} - {playerCurrentArea.Actions[i].Description}");
      }

      int chosenAction = Int32.Parse(_input.GetInputFromUser()) - 1;
      playerCurrentArea.Actions[chosenAction].Perform(_player, _areas);



      isRunning = Step(playerCurrentArea.Connections, playerCurrentArea.Actions[chosenAction].AfterDescription);

    }
  }

  private void LoadArea()
  {
    string[] triggers = new string[] { "move", "m", "go" };
    MA.Move action = new("move", triggers, "I moved to the next area", 1);
    MA.Action[] actionArr = new MA.Move[] { action };

    MA.Move action2 = new("move", triggers, "I moved to the next area", 2);
    MA.Action[] actionArr2 = new MA.Move[] { action2 };


    _areas[0] = new Area(0, "Start room", actionArr, new int[] { 1 });
    _areas[1] = new Area(1, "Room 1", actionArr2, new int[] { 2 });
    _areas[2] = new Area(2, "End room", null, null);
    //_areas[3] = new Area("Room 3");
    //_areas[4] = new Area("Room 4");
    //_areas[5] = new Area("Room 5");
    //_areas[6] = new Area("Room 6");
  }

  private void CreatePlayer()
  {
    _display.PrintMessage("Please choose a name for your character.");
    string nameOfCharacter = _input.GetInputFromUser();
    Player player = new(nameOfCharacter, _areas[0]);
    _player = player;
  }


  private bool Step(int[]? conn, string message)
  {
    if (conn is null)
    {
      return false;
    }
    else
    {
      _display.PrintMessage(message);
      return true;
    }
  }
}
