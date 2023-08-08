using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.Service.Actions;

public class MathPuzzle : Action
{
    private readonly int _number1;

    private readonly int _number2;

    public int Answer => _number1 + _number2;
    
    public MathPuzzle(string description, string[] triggers, string afterDescription) : base(description, triggers, afterDescription)
    {
        Random random = new Random();
        _number1 = random.Next(100);
        _number2 = random.Next(100);
    }

    public override void Perform(Player player, Area[] areas)
    {
        Console.WriteLine($"What is {_number1} + {_number2}?");
        var playerAnswer = int.Parse(Console.ReadLine());
        if (playerAnswer == Answer)
        {
            Console.WriteLine("Correct");
            player.CurrentArea.Actions.Remove(this);
        }
    }
}