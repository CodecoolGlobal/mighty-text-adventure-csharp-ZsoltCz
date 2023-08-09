using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class MathPuzzle : Action
{
    private readonly int _number1;

    private readonly int _number2;

    private readonly Action _actionToUnlock;

    private readonly string _failureDescription;

    public int Answer => _number1 + _number2;
    
    public MathPuzzle(string description, string[] triggers, string afterDescription, string failureDescription, Action actionToUnlock) : base(description, triggers, afterDescription)
    {
        Random random = new Random();
        _number1 = random.Next(100);
        _number2 = random.Next(100);
        _actionToUnlock = actionToUnlock;
        _failureDescription = failureDescription;
    }

    public override string Perform(Player player, Area[] areas)
    {
        Console.WriteLine($"What is {_number1} + {_number2}?");
        var playerAnswer = int.Parse(Console.ReadLine());
        if (playerAnswer == Answer)
        {
            player.CurrentArea.Actions.Remove(this);
            player.CurrentArea.Actions.Add(_actionToUnlock);
            return AfterDescription;
        }

        return _failureDescription;
    }
}