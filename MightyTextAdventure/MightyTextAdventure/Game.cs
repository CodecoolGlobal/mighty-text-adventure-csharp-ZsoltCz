using MightyTextAdventure.Data.Places;
using MightyTextAdventure.UI;

namespace MightyTextAdventure;

public class Game
{
    private readonly Area[] _areas;

    private readonly Input _input;
    private readonly Display _display;

    public Game()
    {
        _areas = new Area[7];
        _input = new Input();
        _display = new Display();
    }

    public void Init()
    {
        LoadArea();
    }

    public void Run()
    {
        bool isRunning = true;
        while (isRunning)
        {
            isRunning = Step();
        }
    }

    private void LoadArea()
    {
        _areas[0] = new Area("Start room");
        _areas[1] = new Area("Room 1");
        _areas[2] = new Area("Room 2");
        _areas[3] = new Area("Room 3");
        _areas[4] = new Area("Room 4");
        _areas[5] = new Area("Room 5");
        _areas[6] = new Area("Room 6");
    }


    private bool Step()
    {
        _display.PrintMessage("steps");
        return true;
    }
}
